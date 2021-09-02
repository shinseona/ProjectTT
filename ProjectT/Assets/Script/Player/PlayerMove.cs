using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX, moveY;
    private Animator playerAnim;
    private bool playerMoving;
    private Vector2 lastMove;
    [Header("이동속도 조절")]
    [SerializeField] [Range(1f, 3000f)] 
    private float moveSpeed = 1500f;
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    void Update()
    {
        playerMoving = false;
        //moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveX = GetHorizontal(KeyCode.A,KeyCode.D) * moveSpeed * Time.deltaTime;
        moveY = GetVertical(KeyCode.W, KeyCode.S) * moveSpeed * Time.deltaTime;
        if (GetHorizontal(KeyCode.A, KeyCode.D)!=0)
        {
            transform.position = new Vector2(transform.position.x+moveX, transform.position.y);
            playerMoving = true;
            lastMove = new Vector2(GetHorizontal(KeyCode.A, KeyCode.D), 0f);
        }

        if (GetVertical(KeyCode.W, KeyCode.S)!=0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+moveY);
            playerMoving = true;
            lastMove = new Vector2(0f, GetVertical(KeyCode.W, KeyCode.S));
        }

        playerAnim.SetBool("PlayerMoving", playerMoving);
        playerAnim.SetFloat("MoveX", GetHorizontal(KeyCode.A, KeyCode.D));
        playerAnim.SetFloat("MoveY", GetVertical(KeyCode.W, KeyCode.S));
        playerAnim.SetFloat("LastMoveX", lastMove.x);
        playerAnim.SetFloat("LastMoveY", lastMove.y);
        //transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }

    private int GetHorizontal(KeyCode k1, KeyCode k2)
    {
        int ReturnNum = 0;
        if (Time.timeScale == 0f) return ReturnNum;
        if(Input.GetKey(k1))
        {
            ReturnNum = -1;
        }
        if (Input.GetKey(k2))
        {
            ReturnNum = 1;
        }

        return ReturnNum;
    }
    private int GetVertical(KeyCode k1, KeyCode k2)
    {
        int ReturnNum = 0;

        if (Time.timeScale == 0f) return ReturnNum;

        if (Input.GetKey(k1))
        {
            ReturnNum = 1;
        }
        if (Input.GetKey(k2))
        {
            ReturnNum = -1;
        }
        return ReturnNum;
    }
}
