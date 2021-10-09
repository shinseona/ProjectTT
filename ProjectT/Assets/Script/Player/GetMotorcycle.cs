using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMotorcycle : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> MotorcycleView;
    private GameObject MotorcycleObj;
    public GameObject itemDialogE;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Motorcycle")
        {
            if (itemDialogE.activeSelf != true)
            {
                ItmeDialogOn();
            }
            MotorcycleInfo motorcycle = collision.transform.parent.GetComponent<MotorcycleInfo>();
            MotorcycleObj = MotorcycleView[motorcycle.motorcycleNum];
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
}
