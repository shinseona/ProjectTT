using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadCoin : MonoBehaviour
{
    private PlayerInventoryInfo iteminof;
    [SerializeField] private TextMeshProUGUI Coin;

    void Start()
    {
        iteminof = GameObject.Find("ItemInfo").GetComponent<PlayerInventoryInfo>();
        
    }
    void Update()
    {
        Coin.SetText(iteminof.Playercoin.ToString() + "¿ø");
    }
}
