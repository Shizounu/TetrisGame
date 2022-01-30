using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public class TetrominoManager : MonoBehaviour
{
   #region variables
    [Header("Working Variables")]
    public Tetromino heldTetromino;
    public Tetromino activeTetromino;  
    public float gameSpeed{
        get{return (1 + (destroyedLines / 15));}
    }
    public bool hasLost = false;
    public float destroyedLines = 0;
    public bool isPaused = false;
    [Header("References")]
    public InputActions input;
    public List<GameObject> TetrominoPrefabs;
    public Transform[,] filledMinos;

    #endregion

   #region GameManagment
    public void updateBoard(Tetromino tetromino){
        bool boardDirty = false;
        //Delete the old minos of the previous iteration
        for (int y = 0; y < 20; y++){
            bool isLineFilled = true;
            for (int x = 0; x < 10; x++){
                if(filledMinos[x,y] != null && filledMinos[x,y].parent == tetromino.transform){
                    filledMinos[x,y] = null;
                } 

                if(filledMinos[x,y] == null){
                    isLineFilled = false;
                }
            }

            //Delete filled line
            if(isLineFilled){
                boardDirty = true;
                destroyedLines++;
                OnLineClear();
                for (int x = 0; x < 10; x++)
                    Destroy(filledMinos[x, y].gameObject);
            
                for (int y1 = y; y1 < 20; y1++){
                    for (int x = 0; x < 10; x++){
                        if(y1 + 1 < 20){
                            filledMinos[x,y1] = filledMinos[x,y1+1];
                            if(filledMinos[x,y1] != null)
                                filledMinos[x,y1].position += Vector3.down;
                        }
                        else
                            filledMinos[x,y1] = null;
                    }
                }
            }

        }
        //Write the new minos into the board
        foreach (GameObject mino in tetromino.minos){
            Vector2 pos = new Vector2(Mathf.Round(mino.transform.position.x - .5f), Mathf.Round(mino.transform.position.y - .5f));
            if(pos.y < 20)
                filledMinos[(int)pos.x,(int)pos.y] = mino.transform;
        }

        if(boardDirty)
            updateBoard(tetromino);
    }

    public Transform getFilledMino(Vector2 pos){
        if(pos.y > 20)
            return null;
        return filledMinos[Mathf.RoundToInt(pos.x -.5f), Mathf.RoundToInt(pos.y-.5f)];
    }

    public void gameOver(){
        hasLost = true;
    }

    private void newTetromino(){

        Tetromino go = Instantiate(TetrominoPrefabs[Random.Range(0,TetrominoPrefabs.Count)], new Vector3(4f,19f), new Quaternion()).GetComponent<Tetromino>();
        go.timeScale = gameSpeed;
        activeTetromino = go;
        go.manager = this;

        //Subscribe to audio events
        activeTetromino.OnMove += OnMove;
        activeTetromino.OnLand += OnLand;
        activeTetromino.OnRotate += OnRotate;
    }

    private void holdTetromino(){
        if(heldTetromino == null){
            heldTetromino = activeTetromino;
            newTetromino();
            
            for (int i = 0; i < 4; i++){
                if((heldTetromino.minos[i].transform.position.y - .5f) < 20)
                    filledMinos[(int)(heldTetromino.minos[i].transform.position.x - .5f),(int)(heldTetromino.minos[i].transform.position.y - .5f)] = null;
            }

            heldTetromino.transform.position = new Vector3(-3.5f,15.5f);
            heldTetromino.transform.rotation = new Quaternion();
            heldTetromino.enabled = false;
        } else {
            //Perform the swap
            var newHeldTetromino = activeTetromino;
            activeTetromino = heldTetromino;
            
            //Prepare the tetromino
            activeTetromino.enabled = true;
            activeTetromino.timeScale = gameSpeed;
            activeTetromino.manager = this;
            activeTetromino.tickTime = 0;
            activeTetromino.transform.position = new Vector3(4f,19f);
           
           //make the held tetromino the actual held tetromino and clean up
            heldTetromino = newHeldTetromino;

            for (int i = 0; i < 4; i++){
                if((heldTetromino.minos[i].transform.position.y - .5f) < 20)
                    filledMinos[(int)(heldTetromino.minos[i].transform.position.x - .5f),(int)(heldTetromino.minos[i].transform.position.y - .5f)] = null;
            }
            heldTetromino.transform.position = new Vector3(-3.5f,15.5f);
            heldTetromino.transform.rotation = new Quaternion();
            heldTetromino.enabled = false;
        }
    }

    private void Pause(){
        if(!isPaused){
            activeTetromino.enabled = false;
            isPaused = true;
            input.Tetris.Disable();
        } else{
            activeTetromino.enabled = true;
            isPaused = false;
            input.Tetris.Enable();
        }
    
    }
   #endregion
   
   #region Unity Functions
    private void Awake() {
        //Instantiate references
        input = new InputActions();
        filledMinos = new Transform[10,20];
        Tetromino aTetromino = null;
        //Subscribe to input events
        input.Tetris.Move.performed += ctx => activeTetromino.shift((int)ctx.ReadValue<float>());
        input.Tetris.RotateClockwise.performed += _ => activeTetromino.rotateClockwise();
        input.Tetris.RotateCounterclockwise.performed += _ => activeTetromino.rotateCounterClockwise();

        input.Tetris.SoftDrop.performed += _ => { 
            aTetromino = activeTetromino;
            activeTetromino.timeScale *= 2;
        };
        input.Tetris.SoftDrop.canceled += _ => {
            if(aTetromino == activeTetromino)
                activeTetromino.timeScale /= 2;
        };
        input.Tetris.HardDrop.performed += _ => activeTetromino.hardDrop();
        input.Tetris.Hold.performed += _ => holdTetromino();

        input.Menu.Pause.performed += _ => Pause();
    }
    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();

    private void Start() {
        //Spawns initial tetromino
        newTetromino();
    }

    private void Update() {
        if(hasLost)
            return;

        //Spawns new tetromino when old one is done with its journey
        if(activeTetromino.isGrounded){
            newTetromino();
        }
    }

    private void OnDrawGizmos() {

        //Visualizes the board for debugging purposes
        if(filledMinos == null)
            return;
        for (int y = 0; y < 20; y++){
            for (int x = 0; x < 10; x++){
                if(filledMinos[x,y] != null){
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(new Vector3(x + 0.5f,y + 0.5f,-.1f),new Vector3(1,1,.1f));

                    Handles.Label(new Vector3(x +.5f,y +.5f,0),$"{x}/{y}");
                } else {
                    Gizmos.color = Color.white;
                    Gizmos.DrawWireCube(new Vector3(x + 0.5f,y + 0.5f,0),new Vector3(1,1,0));

                    Handles.Label(new Vector3(x+.5f,y+.5f,0),$"{x}/{y}");
                }
            }
        }
    }

    #endregion

   #region UI

   public TextMeshProUGUI ScoreText;
    
   private void OnGUI() {
       ScoreText.text = $"Score: {destroyedLines}";
   }
   #endregion

    #region Audio event stuff
    [Header("Audio References")]
    public AudioSource MoveSound;
    public AudioSource LandSound;
    public AudioSource RotateSound;
    public AudioSource LineClearSound;
    public void OnMove(){
        MoveSound.Play();
    }
    public void OnLand(){
        LandSound.Play();
    }
    public void OnRotate(){
        RotateSound.Play();
    }
    public void OnLineClear(){
        LineClearSound.Play();
    }
    #endregion

}