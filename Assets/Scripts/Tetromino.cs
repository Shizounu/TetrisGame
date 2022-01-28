using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Tetromino : MonoBehaviour
{
    [SerializeField] private float tickTime;
    public float timeScale;
    public bool isGrounded = false;
    public GameObject[] minos;
    public TetrominoManager manager;

    public bool isMinoPositionValid(Vector2 pos){
        //Checks if minos is in bound
        if (!((pos.x  >= 0) && (pos.x + .5f  <= 10) && (pos.y  > 0))){
            Debug.Log($"Mino at {pos} is outside the grid");
            return false;
        }

        //Checks if the positions of the minos is taken by another minos
        if(manager.getFilledMino(pos) != null && manager.getFilledMino(pos).parent != transform)
            return false;
    
        return true;
    }

    public bool isTetrominoPositionValid(){
        for (int i = 0; i < minos.Length; i++){
            if(!isMinoPositionValid(new Vector2(minos[i].transform.position.x,minos[i].transform.position.y)))
                return false;
        }
        return true;
    }


    //rotates the tetromino
    public void rotateClockwise(){
        transform.Rotate(new Vector3(0,0,90));
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x),Mathf.RoundToInt(transform.position.y));

        if(!isTetrominoPositionValid()){
            transform.Rotate(new Vector3(0,0,-90));
            Debug.Log("I hit a wall while rotating clockwise");
        }else
            manager.updateBoard(this);
    }
    public void rotateCounterClockwise(){
        transform.Rotate(new Vector3(0,0,-90));
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y);

        if(!isTetrominoPositionValid()){
            transform.Rotate(new Vector3(0,0,90));
            Debug.Log("I hit a wall while rotating clockwise");
        }else
            manager.updateBoard(this);
    }
    //moves the object left/right
    public void shift(int dir){
        transform.position += new Vector3(dir,0,0);
        if(!isTetrominoPositionValid()){
            transform.position -= new Vector3(dir,0,0);
            Debug.Log("I hit a wall while shifting");
        }else
            manager.updateBoard(this);

    }
    
    private void Update(){
        
        if (!isGrounded){
            tickTime += Time.deltaTime * timeScale;
            if (tickTime >= 1){
                transform.position += Vector3.down;
                tickTime = 0;

                if (!isTetrominoPositionValid()){
                    transform.position -= Vector3.down;
                    isGrounded = true;
                } else {
                    manager.updateBoard(this);
                }
            }
        }
    }
}
