using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMotorcycle : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> motorcycleView;
    [SerializeField]
    private GameObject playerMotorcycle;
    private GameObject MotorcycleObj;
    public GameObject itemDialogE;
    MainPlayerCamera vcam;

    private void Start()
    {
        vcam = transform.parent.gameObject.GetComponent<MainPlayerCamera>();
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
            if (Input.GetKey(KeyCode.E))
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
        switch(viewName)
        {
            case "Motorcycle_front":
                return Vector2Int.down;
            case "Motorcycle_Back":
                return Vector2Int.up;
            case "Motorcycle_Laft":
                return Vector2Int.left;
            case "Motorcycle_Right":
                return Vector2Int.right;
        }
        return Vector2Int.zero;
    }
    private void GetMotocycleForPlayer(Vector2Int _motorcycleView, Collider2D collision)
    {
        playerMotorcycle.transform.position = collision.transform.position;
        playerMotorcycle.SetActive(true);
        playerMotorcycle.gameObject.GetComponent<PlayerMove>().lastMove = _motorcycleView;
        vcam.ControlCam(playerMotorcycle.transform);
        gameObject.SetActive(false);
        collision.transform.parent.gameObject.SetActive(false);
    }
}
