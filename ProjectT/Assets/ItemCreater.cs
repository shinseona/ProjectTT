using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using Random = UnityEngine.Random;

public class ItemCreater : MonoBehaviour
{
    [SerializeField]
    private List<PlacedObject> placedObjects = new List<PlacedObject>();
    private InventoryTetrisManualPlacement inventoryTetris;
    private JsonData shippingAddressData;

    private int random;

    private int shippingAddressRandom;
    // Start is called before the first frame update
    void Start()
    {
        string shippingAddressJson = File.ReadAllText(Application.dataPath + "/Resources/ShippingAddress.json");
        shippingAddressData = JsonMapper.ToObject(shippingAddressJson);
        inventoryTetris = GetComponent<InventoryTetrisManualPlacement>();
        CreatItem();
    }

    void Update()
    {
        random = Random.Range(0, placedObjects.Count);
        shippingAddressRandom = Random.Range(0, shippingAddressData.Count);
    }
    // Update is called once per frame
    public void CreatItem()
    {
        ItemInfo iteminfo = placedObjects[random].gameObject.GetComponent<ItemInfo>();
        ItemTetrisSO itemSo = iteminfo.ItemSo;
        var _creatItem=inventoryTetris.CreatItem(itemSo.creatItemPoint, itemSo).gameObject;
        ItemInfo creatItemInfo = _creatItem.GetComponent<ItemInfo>();
        creatItemInfo.ShippingAddress = shippingAddressData[shippingAddressRandom]["address"].ToString();
        creatItemInfo.NPCName = shippingAddressData[shippingAddressRandom]["npcName"].ToString();
    }
}


