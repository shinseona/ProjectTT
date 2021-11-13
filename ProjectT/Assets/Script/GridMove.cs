using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    private Vector3 gridTransform;
    private float gridMoveSpeed = 5.0f; //그리드 이동시 속도
    private float gridMoveDistance = 1f;  //그리드 이동거리
    private bool gridCanMove = true;    //그리드 이동이 가능한가?
    private bool gridMoveDelay = false; //이동버튼을 누르고 있을때 그리드 이동후 잠시 멈추는 효과를 주기위한 변수
    private float gridMoveDelayTime = 0.05f;    //이동버튼을 누르고 있을때 그리드 이동시 잠시 멈춤효과 시간
    private int maxScore = 0;
    private int nowPoint = 0;
    void Start()
    {
        gridTransform = transform.position;
        maxScore = 0;
        nowPoint = 0;
    }

    void FixedUpdate()
    {
        float hori_raw = Input.GetAxisRaw("Horizontal");
        float ver_raw = Input.GetAxisRaw("Vertical");

        if (gridTransform == transform.position)
        {
            if (gridCanMove == true)
            {
                switch (hori_raw)
                {
                    case 1:
                        if ((gridTransform + (Vector3.right * gridMoveDistance)).x < 9f)
                        {
                            gridTransform += Vector3.right * gridMoveDistance;
                        }

                        break;
                    case -1:
                        if ((gridTransform + (Vector3.left * gridMoveDistance)).x > -9f)
                        {
                            gridTransform += Vector3.left * gridMoveDistance;
                        }
                        break;
                }

                switch
                    (ver_raw)
                {
                    case 1:
                        gridTransform += Vector3.up * gridMoveDistance;
                        nowPoint++;
                        if (nowPoint == maxScore + 1)
                        {
                            maxScore++;
                            CountScore.Static_AddScore(1);
                        }

                        break;
                    case -1:
                        gridTransform += Vector3.down * gridMoveDistance;
                        nowPoint--;
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
            transform.position = Vector3.MoveTowards(transform.position, gridTransform, Time.deltaTime * gridMoveSpeed);    // Move there
        }
    }

    IEnumerator GridMoveDelay()
    {
        yield return new WaitForSeconds(gridMoveDelayTime);
        gridCanMove = true;
        gridMoveDelay = false;
    }

}
