using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShippingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Fkey;

    [SerializeField] private TextMeshProUGUI CoinViewer;
    

    private PlayerInventoryInfo playerInventory;
    void Start()
    {
        playerInventory = GameObject.Find("ItemInfo").gameObject.GetComponent<PlayerInventoryInfo>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Addr")
        {
            Fkey.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                var addrMgr=col.gameObject.GetComponent<AddrManager>();
                var addr = addrMgr.Addr;
                playerInventory.AddrChack(addr);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Addr")
        {
            Fkey.SetActive(false);
        }
    }
}
