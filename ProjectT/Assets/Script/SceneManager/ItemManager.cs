using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<ItemInfo> itemInfoList = new List<ItemInfo>();
    public List<GameObject> tileWallList = new List<GameObject>();
    public List<TileWall> isFulltileWallList = new List<TileWall>();
    public int tileNum=0;
    [SerializeField]
    private List<GameObject> itemList;
    public GameObject inventory;
    void Start()
    {
        foreach(var itemPull in tileWallList)
        {
            isFulltileWallList.Add(itemPull.GetComponent<TileWall>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("sadsad");
            bool isActive = inventory.activeSelf;
            inventory.SetActive(!isActive);
        }
    }
}
