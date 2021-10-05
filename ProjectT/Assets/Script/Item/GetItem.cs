using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private ItemManager itemManager;
    public GameObject itemDialogE;
    public GameObject parentObj;
    private void Start()
    {
        itemManager = transform.parent.GetComponent<ItemManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            if (itemDialogE.activeSelf != true)
            {
                ItmeDialogOn();
            }
            if(Input.GetKey(KeyCode.E))
            {
                //temp.transform.parent= parentObj.transform;
                for (int i = 0; i < itemManager.isFulltileWallList.Count; i++)
                {
                    var _fullList = itemManager.isFulltileWallList[i];
                    
                    if (_fullList.IsFull == false)
                    {
                        var _tileList = itemManager.tileWallList[i];
                        
                        GameObject temp = new GameObject();
                        temp = collision.transform.parent.gameObject;
                        ItemInfo iteminfo = temp.GetComponent<ItemInfo>();
                        _fullList.maxItem = iteminfo.maxCarryingCapacity;
                        _fullList.itemID = iteminfo.ItemID;
                        _fullList.nowItem++;
                        _fullList.IsFull = true;
                        temp.transform.parent = _tileList.transform;
                        temp.transform.position = _tileList.transform.position;
                        _tileList = temp.transform.parent.gameObject;
                        temp.GetComponent<SpriteRenderer>().sortingOrder = 11;

                        return;
                    }
                    else if(_fullList.IsFull==true &&_fullList.maxItem > _fullList.nowItem)
                    {
                        GameObject temp = new GameObject();
                        temp = collision.transform.parent.gameObject;
                        ItemInfo iteminfo = temp.GetComponent<ItemInfo>();
                        if (iteminfo.ItemID == _fullList.itemID)
                        {
                            Destroy(temp);
                            _fullList.nowItem++;
                            return;
                        }
                    }
                }
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
}
