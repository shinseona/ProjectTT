using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    private float MoveDown;
    [Header("이동속도 조절")]
    [SerializeField]
    [Range(1f, 20f)]
    private float playerMoveSpeed = 2f;
    private float Score = 0;


    void FixedUpdate()
    {
        
        MoveDown = -1 * playerMoveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + MoveDown);
        Score += MoveDown;
        if (Score < -1)
        {
            CountScore.Static_AddScore(1);
            Score = 0;
        }
    }


}
