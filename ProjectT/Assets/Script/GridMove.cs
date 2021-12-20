using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMove : MonoBehaviour
{
    private float MoveDown;
    [Header("이동속도 조절")]
    [SerializeField]
    [Range(1f, 20f)]
    public float playerMoveSpeed = 2f;
    private float Score = 0;
    public bool gridMove = false;
    private float nowPoint;
    public Image Speedbar;


    void Start()
    {
        StartCoroutine(GridMoveDelay());
        Score =transform.position.y;
    }
    void FixedUpdate()
    {
        nowPoint = transform.position.y;
        if (gridMove)
        {
            Speedbar.fillAmount = playerMoveSpeed / 6.0f;
            if (playerMoveSpeed < 4.0f)
            {
                playerMoveSpeed += 1f* Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (3.9f < playerMoveSpeed && playerMoveSpeed < 6.0f)
                {
                    playerMoveSpeed += 0.5f * Time.deltaTime;
                }
            }
            MoveDown = -1 * playerMoveSpeed * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + MoveDown);
            if (nowPoint < Score - 1)
            {
                CountScore.Static_AddScore(1);
                Score -= 1;
            }
        }
    }

    IEnumerator GridMoveDelay()
    {
        gridMove = false;
        yield return new WaitForSecondsRealtime(5f);
        gridMove = true;
    }

}
