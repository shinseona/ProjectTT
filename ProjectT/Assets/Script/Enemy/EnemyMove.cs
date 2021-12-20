using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float MoveDown, MoveX=0;
    private float playerMoveSpeed = 2f;
    private float Score = 0;
    private Vector3 gridTransform;
    private GridMove GetPlayerSpeed;
    public Vector3 GridTransform
    {
        get => gridTransform;
        set => gridTransform = value;
    }
    private EnemyPoolable enemyPoolable;
   public bool _isMoveRight;
   private Animator anim;
    void Start()
    {
        gridTransform = transform.position;
        enemyPoolable = gameObject.GetComponent<EnemyPoolable>();
        GetPlayerSpeed = GameObject.Find("backG").GetComponent<GridMove>();
        anim = gameObject.GetComponent<Animator>();
       
        if(_isMoveRight)
        anim.SetTrigger("Right");
        else
        anim.SetTrigger("Left");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetPlayerSpeed.gridMove)
        {
            MoveDown = -1 * GetPlayerSpeed.playerMoveSpeed * Time.deltaTime;
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
            
            transform.position = new Vector2(transform.position.x + MoveX, transform.position.y + MoveDown);
        }
    }

}
