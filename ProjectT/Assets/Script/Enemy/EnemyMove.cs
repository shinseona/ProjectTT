using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float MoveDown, MoveX=0;
    private float playerMoveSpeed = 2f;
    private float Score = 0;
    private Vector3 gridTransform;
    public Vector3 GridTransform
    {
        get => gridTransform;
        set => gridTransform = value;
    }
    private EnemyPoolable enemyPoolable;
   public bool _isMoveRight;

    void Start()
    {
        gridTransform = transform.position;
        enemyPoolable = gameObject.GetComponent<EnemyPoolable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveDown = -1 * playerMoveSpeed * Time.deltaTime;
        switch (_isMoveRight)
        {
            case true:
                MoveX = 1 * playerMoveSpeed * Time.deltaTime;
                if (transform.position.x > 5)
                {
                    MoveX = 0;
                    enemyPoolable.Push();
                }
                
                break;
            case false:
                MoveX = -1 * playerMoveSpeed * Time.deltaTime;
                if (transform.position.x < -5f)
                {
                    MoveX = 0;
                    enemyPoolable.Push();
                }
                break;
        }
        Debug.Log(MoveX);
        transform.position = new Vector2(transform.position.x+ MoveX, transform.position.y+ MoveDown);
    }

}
