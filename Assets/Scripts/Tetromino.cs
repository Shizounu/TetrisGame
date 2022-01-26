using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [SerializeField] private float tickTime;
    public float timeScale;
    public bool isGrounded = false;
    public static int GridWidth = 10;

    public GameObject[] minos;

    public bool isMinoInGrid(Vector2 pos){
        return ((int)pos.x-1 >= 0 && (int)pos.x+1 <= GridWidth && (int)pos.y >= 0);
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
    }
    public void rotateCounterClockwise(){
        transform.Rotate(new Vector3(0,0,-90));
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y);
    }

    //moves the object left/right
    public void shift(int dir){
        if(isGrounded)
            return;
        transform.position += new Vector3(dir,0,0);
        if(!isTetrominoInGrid())
            transform.position -= new Vector3(dir,0,0);
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
                }
            }
        }
    }
}
