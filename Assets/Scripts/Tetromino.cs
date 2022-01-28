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

    public bool isMinoInGrid(Vector2 pos){
        //Checks if minos is in bound
        if (!((pos.x  >= 0) && (pos.x +.5  <= 10) && (pos.y  > 0))){
            Debug.Log($"Mino at {pos} is outside the grid");
            return false;
        }

        //Checks if the positions of the minos is taken by another minos
        if(manager.getFilledMino(pos) != null && manager.getFilledMino(pos) != minos.Any()){
            Debug.Log($"Mino at {pos} hit another mino");
            
            return false;
        }
    
        return true;
    }

    public bool isTetrominoInGrid(){
        for (int i = 0; i < minos.Length; i++){
            if(!isMinoInGrid(new Vector2(minos[i].transform.position.x,minos[i].transform.position.y)))
                return false;
        }
        return true;
    }


    //rotates the tetromino
    public void rotateClockwise(){
        transform.Rotate(new Vector3(0,0,90));
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x),Mathf.RoundToInt(transform.position.y));

        if(!isTetrominoInGrid()){
            transform.Rotate(new Vector3(0,0,-90));
            Debug.Log("I hit a wall while rotating clockwise");
        }else
            manager.updateBoard(this);
    }
    public void rotateCounterClockwise(){
        transform.Rotate(new Vector3(0,0,-90));
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y);

        if(!isTetrominoInGrid()){
            transform.Rotate(new Vector3(0,0,90));
            Debug.Log("I hit a wall while rotating clockwise");
        }else
            manager.updateBoard(this);
    }

    //moves the object left/right
    public void shift(int dir){
        transform.position += new Vector3(dir,0,0);
        if(!isTetrominoInGrid()){
            transform.position -= new Vector3(dir,0,0);
            Debug.Log("I hit a wall whileshifting");
        }else
            manager.updateBoard(this);

    }
    private void Update()
    {
        if (!isGrounded)
        {
            tickTime += Time.deltaTime * timeScale;
            if (tickTime > 1)
            {
                transform.position += Vector3.down;
                tickTime = 0;
                if (!isTetrominoInGrid())
                {
                    transform.position -= Vector3.down;
                    isGrounded = true;
                } else {
                    manager.updateBoard(this);
                }
            }
        }
    }
}
