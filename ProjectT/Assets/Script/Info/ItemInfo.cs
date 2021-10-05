using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    private int itemID;
    public int ItemID { get => itemID;}
    public int maxCarryingCapacity;
}
