using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetGridGame : MonoBehaviour
{
    private PlayerInventoryInfo itemInfo;
    public FadeManager fader;
    void Start()
    {
        itemInfo = GameObject.Find("ItemInfo").gameObject.GetComponent<PlayerInventoryInfo>();
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "GridGameZone")
        {
            for (int i = 0; i < itemInfo.itemList.Count; i++)
            {
                itemInfo.itemList[i].transform.parent = itemInfo.transform;
            }

            StartCoroutine(fader.FadeInActiveate(fader, "GridGame"));
            //SceneManager.LoadScene("GridGame");
        }
    }

}
