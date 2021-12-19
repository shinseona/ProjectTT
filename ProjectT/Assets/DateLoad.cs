using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateLoad : MonoBehaviour
{
    private UserDataBase udb;
    [SerializeField] private TextMeshProUGUI date;

    void Start()
    {
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();

    }
    void Update()
    {
        date.SetText(udb.Date);
    }
}
