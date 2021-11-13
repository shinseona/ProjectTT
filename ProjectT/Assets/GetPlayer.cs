using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    private readonly List<Vector2> playerPointList = new List<Vector2>();
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private List<GameObject> motorcycleView;

    private PlayerMove motorcycleMove;
    private MainPlayerCamera vcam;
    public float RayDistance = 0.8f;
    public bool resetMotor;
    GameObject gameManager;
    UserDataBase udb;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();

        playerPointList.Add(Vector2.up);
        playerPointList.Add(Vector2.down);
        playerPointList.Add(Vector2.left);
        playerPointList.Add(Vector2.right);
        motorcycleMove = GetComponent<PlayerMove>();
        vcam = transform.parent.gameObject.GetComponent<MainPlayerCamera>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!resetMotor)
        {
            return;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            foreach (var playerPoint in 
                playerPointList.Where(playerPoint => 
                    !Physics2D.Raycast(transform.position, 
                        playerPoint,
                        RayDistance, 
                        LayerMask.GetMask("Wall"))))
            {
                playerObj.transform.position =
                    new Vector3(transform.position.x + playerPoint.x,
                        transform.position.y + playerPoint.y
                        , 1);
                udb.PlayerisMotorcycle = false;
                GameObject motorcycle = MotorcycleView(motorcycleMove.lastMove);
                motorcycle.transform.position = transform.position;
                playerObj.SetActive(true);
                playerObj.gameObject.GetComponent<PlayerMove>().lastMove = motorcycleMove.lastMove;
                var getPlayer = playerObj.gameObject.GetComponent<GetMotorcycle>();
                getPlayer.resetMotor = false;
                getPlayer.GetPlayerResetTiem();
                vcam.ControlCam(playerObj.transform);
                motorcycle.SetActive(true);
                resetMotor = false;
                gameObject.SetActive(false);
                break;
            }
        }
       
        
    }

    private GameObject MotorcycleView(Vector2Int viewVector)
    {
        if (viewVector == Vector2Int.down)
        {
            return motorcycleView[0];
        }
        else if (viewVector == Vector2Int.up)
        {
            return motorcycleView[1];

        }
        else if (viewVector == Vector2Int.left)
        {
            return motorcycleView[2];

        }
        else if (viewVector == Vector2Int.right)
        {
            return motorcycleView[3];

        }
        else
        {
            return null;
        }
    }

    public void GetMotorcycleResetTiem()
    {
        StartCoroutine(ResetTiem());
    }
    private IEnumerator ResetTiem()
    {
        yield return new WaitForSeconds(1.0f);
        resetMotor = true;
    }
}
