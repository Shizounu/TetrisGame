using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoManager : MonoBehaviour
{
    [Header("Working Variables")]
    public Tetromino heldTetromino;
    public Tetromino activeTetromino;  
    public float gameSpeed = 1;

    [Header("References")]
    public InputActions input;
    public List<GameObject> TetrominoPrefabs;

    private void Awake() {
        input = new InputActions();

        input.Tetris.Move.performed += ctx => activeTetromino.shift((int)ctx.ReadValue<float>());
        input.Tetris.RotateClockwise.performed += _ => activeTetromino.rotateClockwise();
        input.Tetris.RotateCounterclockwise.performed += _ => activeTetromino.rotateCounterClockwise();
    }
    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();


    private Tetromino newTetromino(){
        Tetromino go = Instantiate(TetrominoPrefabs[Random.Range(0,TetrominoPrefabs.Count)], new Vector3(4f,19f), new Quaternion()).GetComponent<Tetromino>();
        go.timeScale = gameSpeed;
        return go;
    }

    private void Start() {
        activeTetromino = newTetromino();
    }
}
