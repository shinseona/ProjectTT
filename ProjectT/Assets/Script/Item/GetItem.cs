using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    //private ItemManager itemManager;
    public GameObject itemDialogE;
    public GameObject parentObj;
    [SerializeField] private InventoryTetrisManualPlacement inventoryTetris;

    private void Start()
    {
        //itemManager = transform.parent.GetComponent<ItemManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            if (itemDialogE.activeSelf != true)
            {
                ItmeDialogOn();
            }
            if (Input.GetKey(KeyCode.E))
            {
                GetItemForPlayerInventory(collision);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
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
    private void GetItemForPlayerInventory(Collider2D collision)
    {
        ItemInfo itemInfo = collision.transform.parent.GetComponent<ItemInfo>();
        inventoryTetris.GetItem(itemInfo.ItemID);
        Destroy(collision.transform.parent.gameObject);
    }
}
