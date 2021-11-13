using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Vector3 gridTransform;
    public Vector3 GridTransform
    {
        get => gridTransform;
        set => gridTransform = value;
    }
    private EnemyPoolable enemyPoolable;
    [SerializeField]
    private float gridMoveSpeed = 3.0f; //그리드 이동시 속도
    private float gridMoveDistance = 1f; //그리드 이동거리
    private bool gridCanMove = true; //그리드 이동이 가능한가?
    private bool gridMoveDelay = false; //이동버튼을 누르고 있을때 그리드 이동후 잠시 멈추는 효과를 주기위한 변수
    private float gridMoveDelayTime = 0.05f; //이동버튼을 누르고 있을때 그리드 이동시 잠시 멈춤효과 시간
    public bool _isMoveRight;

    void Start()
    {
        gridMoveSpeed = Random.Range(3.0f, 5.0f);
        gridTransform = transform.position;
        enemyPoolable = gameObject.GetComponent<EnemyPoolable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gridTransform == transform.position)
        {
            if (gridCanMove == true)
            {
                switch (_isMoveRight)
                {
                    case true:
                        gridTransform += Vector3.right * gridMoveDistance;
                        if (gridTransform.x > 10)
                            enemyPoolable.Push();

                        break;
                    case false:
                        gridTransform += Vector3.left * gridMoveDistance;
                        if (gridTransform.x < -10f)
                            enemyPoolable.Push();

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
