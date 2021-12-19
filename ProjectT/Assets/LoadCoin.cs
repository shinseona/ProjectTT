using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadCoin : MonoBehaviour
{
    private PlayerInventoryInfo iteminof;
    private UserDataBase udb;
    [SerializeField] private TextMeshProUGUI Coin;

    void Start()
    {
        iteminof = GameObject.Find("ItemInfo").GetComponent<PlayerInventoryInfo>();
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();
    }
    void Update()
    {
        Coin.SetText(udb.Money.ToString() + "¿ø");
    }
}
