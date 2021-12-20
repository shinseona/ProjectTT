using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryInfo : MonoBehaviour
{
    
    public List<ItemInfo> itemList = new List<ItemInfo>();
    public UserDataBase udb;
    private int itemWeight = 0;
    public int Playercoin=0;

    void Start()
    {
    }
    public void ItemInit(ItemInfo _iteminfo)
    {
        itemList.Add(_iteminfo);
    }

    public void CItem(ItemInfo _Lastinfo, ItemInfo _newinfo, Vector2Int newPoint)
    {
        for(int i = 0 ; i<itemList.Count;i++)
        {
            if (itemList[i] == _Lastinfo)
            {
                _newinfo.SavePoint = newPoint;
                _newinfo.ShippingAddress = _Lastinfo.ShippingAddress;
                _newinfo.NPCName = _Lastinfo.NPCName;
                itemList[i] = _newinfo;
                break;
            }
        }
        
    }

    public void AddrChack(string _addr)
    {
        int coin=0;
        int i=0;
        while (i < itemList.Count)
        {
            if (itemList[i].ShippingAddress == _addr)
            {
                coin += itemList[i].ItemSo.itemMoney;
                
                var temp = itemList[i];
                itemList.Remove(itemList[i]);
                Destroy(temp.gameObject);
            }
            else
            {
                ++i;
            }
        }

        Playercoin += coin; 
        udb.Money += coin;
    }
    public void ItemRemove(ItemInfo _iteminfo)
    {
        foreach (var a in itemList)
        {
            if (a.SavePoint == _iteminfo.SavePoint)
            {
                if (itemList.Count == 1)
                {
                    itemList = null;
                    itemList = new List<ItemInfo>();
                    itemWeight = 0;
                    break;
                }
                itemWeight -= _iteminfo.ItemSo.weight;
                itemList.Remove(a);
                break;
            }
        }
    }
}
