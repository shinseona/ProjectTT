using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX, moveY;
    private Animator playerAnim;
    private bool playerMoving;
    public Vector2Int lastMove;

    [Header("이동속도 조절")]
    [SerializeField] [Range(1f, 20f)]
    private float playerMoveSpeed = 2f;


    private bool isPlayerMoveMode = true;
    public bool IsPlayerMoveMode { get => isPlayerMoveMode; set => isPlayerMoveMode = value; }
    GameObject gameManager;
    UserDataBase udb;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        playerAnim = transform.GetComponent<Animator>();
        //if (udb.PlayerGenderMale == true)
        //{ 
        //    playerAnim = transform.GetChild(0).GetComponent<Animator>();
        //}
        //else if(udb.PlayerGenderMale == false)
        //{
        //    playerAnim = transform.GetChild(1).GetComponent<Animator>();
        //}
    }
    void FixedUpdate()
    {
        PlayerMoveControl();
    }

    private void PlayerMoveControl()
    {
        playerMoving = false;
        //moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveX = GetHorizontal(KeyCode.A, KeyCode.D) * playerMoveSpeed * Time.deltaTime;
        moveY = GetVertical(KeyCode.W, KeyCode.S) * playerMoveSpeed * Time.deltaTime;
        if (GetHorizontal(KeyCode.A, KeyCode.D) != 0)
        {
            transform.position = new Vector2(transform.position.x + moveX, transform.position.y);
            playerMoving = true;
            lastMove = new Vector2Int(GetHorizontal(KeyCode.A, KeyCode.D), 0);
        }

        if (GetVertical(KeyCode.W, KeyCode.S) != 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveY);
            playerMoving = true;
            lastMove = new Vector2Int(0, GetVertical(KeyCode.W, KeyCode.S));
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
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return ReturnNum;
        }
        if (Input.GetKey(k1))
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

        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return ReturnNum;
        }
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
