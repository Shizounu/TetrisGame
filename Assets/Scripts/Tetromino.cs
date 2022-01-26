using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [SerializeField] private float tickTime;
    public float timeScale;
    public bool isGrounded = false;
    public GameObject[] minos;

    public bool isMinoInGrid(Vector2 pos){
        return ((pos.x  >= 0) && 
                (pos.x  <= 20) && 
                (pos.y  >= 0));
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
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y);

        if(!isTetrominoInGrid()){
            transform.Rotate(new Vector3(0,0,-90));
        }
    }
    public void rotateCounterClockwise(){
        transform.Rotate(new Vector3(0,0,-90));
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y);

        if(!isTetrominoInGrid()){
            transform.Rotate(new Vector3(0,0,90));
        }
    }

    //moves the object left/right
    public void shift(int dir){
        if(isGrounded)
            return;
        transform.position += new Vector3(dir,0,0);
        if(!isTetrominoInGrid())
            transform.position -= new Vector3(dir,0,0);
    }
    public void moveDown(){
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
                }
            }
        }
    }

    private void Update()
    {
        moveDown();
    }
}
