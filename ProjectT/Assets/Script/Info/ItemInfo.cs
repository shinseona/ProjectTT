using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    private ItemTetrisSO itemSo;
    public ItemTetrisSO ItemSo { get => itemSo; set => itemSo = value; }

    private int itemID;
    public int ItemID { get => itemID; set => itemID = value; }

    [SerializeField]
    private string npcName;
    public string NPCName { get => npcName; set=> npcName = value; }
    [SerializeField]
    private string shippingAddress;
    public string ShippingAddress { get => shippingAddress; set => shippingAddress = value; }
    [SerializeField]
    private Vector2Int savePoint;
    public Vector2Int SavePoint { get => savePoint; set => savePoint = value; }

}
