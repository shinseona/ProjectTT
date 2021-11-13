using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetGridGame : MonoBehaviour
{
    private PlayerInventoryInfo itemInfo;

    void Start()
    {
        itemInfo = GameObject.Find("ItemInfo").gameObject.GetComponent<PlayerInventoryInfo>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "GridGameZone")
        {
            for (int i = 0; i < itemInfo.itemList.Count; i++)
            {
                itemInfo.itemList[i].transform.parent = itemInfo.transform;
            }
            
            Debug.Log("GridGame으로 이동");
            SceneManager.LoadScene("GridGame");
        }
    }
}
