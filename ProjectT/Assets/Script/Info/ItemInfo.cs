using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    private int itemID;
    [SerializeField]
    private PlacedObject itemUI;
    public int ItemID { get => itemID; }
    public PlacedObject ItemUI { get => itemUI; }
    public int maxCarryingCapacity;
}
