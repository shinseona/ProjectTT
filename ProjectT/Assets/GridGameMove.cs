using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGameMove : MonoBehaviour
{
    private float moveX, MoveUp;
    [Header("이동속도 조절")]
    [SerializeField]
    [Range(1f, 20f)]
    private float playerMoveSpeed = 2f;

    private Vector3 gridTransform;
    private float gridMoveSpeed = 5.0f; //그리드 이동시 속도
    private float gridMoveDistance = 1f;  //그리드 이동거리
    private bool gridCanMove = true;    //그리드 이동이 가능한가?
    private bool gridMoveDelay = false; //이동버튼을 누르고 있을때 그리드 이동후 잠시 멈추는 효과를 주기위한 변수
    private float gridMoveDelayTime = 0.05f;    //이동버튼을 누르고 있을때 그리드 이동시 잠시 멈춤효과 시간

    private float Score = 0;
    void Start()
    {
        gridTransform = transform.position;
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        PlayerMoveControl();
    }

    private void PlayerMoveControl()
    {

        if (gridTransform == transform.position)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            if (gridCanMove == true)
            {
                switch (moveX)
                {
                    case 1:
                        if ((gridTransform + (Vector3.right * gridMoveDistance)).x < 4f)
                        {
                            gridTransform += Vector3.right * gridMoveDistance;
                        }

                        break;
                    case -1:
                        if ((gridTransform + (Vector3.left * gridMoveDistance)).x > -4f)
                        {
                            gridTransform += Vector3.left * gridMoveDistance;
                        }

                        break;
                }

                gridCanMove = false;
            }
            else
            {
                if (gridMoveDelay == false)
                {
                    gridMoveDelay = true;
                    StartCoroutine("GridMoveDelay");
                }
            }
        }
        else
        {
            transform.position =
                Vector3.MoveTowards(transform.position, gridTransform, Time.deltaTime * gridMoveSpeed); // Move there
        }

    }


    IEnumerator GridMoveDelay()
    {
        yield return new WaitForSeconds(gridMoveDelayTime);
        gridCanMove = true;
        gridMoveDelay = false;

    }
}