using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileWall : MonoBehaviour
{
    public static Vector2 defaultposition;

    private bool isFull = false;
    public bool IsFull { get => isFull; set => isFull = value; }
    public List<GameObject> ItemList;
    public int itemID;
    public int maxItem = 0;
    public int nowItem = 0;
}
