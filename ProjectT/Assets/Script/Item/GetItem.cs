using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    //private ItemManager itemManager;
    [SerializeField] private InventoryTetrisManualPlacement inventoryTetris;
    private List<ItemInfo> itemInfos = new List<ItemInfo>();
    private PlayerInventoryInfo playerInventory;
    private void Start()
    {
        GameObject info = GameObject.Find("ItemInfo").gameObject;
        playerInventory = info.GetComponent<PlayerInventoryInfo>();
        for (int i = 0; i < playerInventory.itemList.Count; i++)
        {
            var item = inventoryTetris.GetItem(playerInventory.itemList[i]);
            var iteminfo = item.gameObject.GetComponent<ItemInfo>();
            playerInventory.itemList[i] = iteminfo;
        }
        for (int i = 0; i < info.transform.childCount; i++)
        {
            Destroy(info.transform.GetChild(i).gameObject);
        }

        
    }

}
