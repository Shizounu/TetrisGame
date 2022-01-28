using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TetrominoManager : MonoBehaviour
{
    #region variables
    [Header("Working Variables")]
    public Tetromino heldTetromino;
    public Tetromino activeTetromino;  
    public float gameSpeed = 1;

    [Header("References")]
    public InputActions input;
    public List<GameObject> TetrominoPrefabs;
    public Transform[,] filledMinos;
    #endregion


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
                for (int x = 0; x < 10; x++)
                    Destroy(filledMinos[x, y].gameObject);
            
                for (int y1 = y; y1 < 20; y1++){
                    for (int x = 0; x < 10; x++){
                        if(y1 + 1 <= 20){
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


    private void newTetromino(){
        Tetromino go = Instantiate(TetrominoPrefabs[Random.Range(0,TetrominoPrefabs.Count)], new Vector3(4f,19f), new Quaternion()).GetComponent<Tetromino>();
        go.timeScale = gameSpeed;
        activeTetromino = go;
        go.manager = this;
    }
    private void Awake() {
        //Instantiate references
        input = new InputActions();
        filledMinos = new Transform[10,20];

        input.Tetris.Move.performed += ctx => activeTetromino.shift((int)ctx.ReadValue<float>());
        input.Tetris.RotateClockwise.performed += _ => activeTetromino.rotateClockwise();
        input.Tetris.RotateCounterclockwise.performed += _ => activeTetromino.rotateCounterClockwise();

        input.Tetris.SoftDrop.performed += _ => { 
            activeTetromino.timeScale *= 2;
        };
        input.Tetris.SoftDrop.canceled += _ => {
            activeTetromino.timeScale /= 2;
        };
        input.Tetris.HardDrop.performed += _ => activeTetromino.hardDrop();
    }
    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();

    private void Start() {
        //Spawns initial tetromino
        newTetromino();
    }

    private void Update() {
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
}



