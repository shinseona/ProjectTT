using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWall : MonoBehaviour
{
    private bool isFull= false;
    public bool IsFull { get => isFull; set => isFull = value; }
    public int itemID;
    public int maxItem=0;
    public int nowItem=0;
}
