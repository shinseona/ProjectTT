using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMotorcycle : MonoBehaviour
{
    [SerializeField] private List<GameObject> motorcycleView;
    [SerializeField] private GameObject playerMotorcycle;
    private GameObject MotorcycleObj;
    public GameObject itemDialogE;
    MainPlayerCamera vcam;
    public bool resetMotor = true;
    
    GameObject gameManager;
    UserDataBase udb;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();

        vcam = transform.parent.gameObject.GetComponent<MainPlayerCamera>();
        resetMotor = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Motorcycle")
        {
            if (itemDialogE.activeSelf != true)
            {
                ItmeDialogOn();
            }

            MotorcycleInfo motorcycle = collision.transform.parent.GetComponent<MotorcycleInfo>();
            MotorcycleObj = motorcycleView[motorcycle.motorcycleNum];

            if (!resetMotor)
            {
                return;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                GetMotocycleForPlayer(MotorcycleView(MotorcycleObj.name), collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Motorcycle")
        {
            if (itemDialogE.activeSelf != false)
            {
                ItmeDialogOff();
            }
        }
    }

    public void ItmeDialogOn()
    {
        itemDialogE.SetActive(true);
    }

    public void ItmeDialogOff()
    {
        itemDialogE.SetActive(false);
    }

    private Vector2Int MotorcycleView(string viewName)
    {
        return viewName switch
        {
            "Motorcycle_front" => Vector2Int.down,
            "Motorcycle_Back" => Vector2Int.up,
            "Motorcycle_Laft" => Vector2Int.left,
            "Motorcycle_Right" => Vector2Int.right,
            _ => Vector2Int.zero
        };
    }

    private void GetMotocycleForPlayer(Vector2Int _motorcycleView, Collider2D collision)
    {
        udb.PlayerisMotorcycle = true;
        playerMotorcycle.transform.position = collision.transform.position;
        playerMotorcycle.SetActive(true);
        playerMotorcycle.gameObject.GetComponent<PlayerMove>().lastMove = _motorcycleView;
        var getPlayer = playerMotorcycle.gameObject.GetComponent<GetPlayer>();
        getPlayer.resetMotor = false;
        getPlayer.GetMotorcycleResetTiem();
        vcam.ControlCam(playerMotorcycle.transform);
        resetMotor = false;
        gameObject.SetActive(false);
        collision.transform.parent.gameObject.SetActive(false);
    }

    public void GetPlayerResetTiem()
    {
        StartCoroutine(ResetTiem());
    }

    private IEnumerator ResetTiem()
    {
        yield return new WaitForSeconds(1.0f);
        resetMotor = true;
    }
}
