using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class UserDataBase : MonoBehaviour
{
    [SerializeField]
    private ulong userSteamID;
    public ulong UserSteamID { get => userSteamID; set => userSteamID = value; }
    [SerializeField]
    private string username;
    public string Username { get => username; set => username = value; }
    [SerializeField]
    private string saveName;
    public string SaveName { get => saveName; set => saveName = value; }
    [SerializeField]
    private string userSeverID;
    public string UserSeverID { get => userSeverID; set => userSeverID = value; }
    
    [SerializeField]
    private string userSeverInDate;
    public string UserSeverInDate { get => userSeverInDate; set => userSeverInDate = value; }

    [SerializeField]
    private bool playerGenderMale;
    public bool PlayerGenderMale { get => playerGenderMale; set => playerGenderMale = value; }
    
    [SerializeField]
    private bool playerisMotorcycle;
    public bool PlayerisMotorcycle { get => playerisMotorcycle; set => playerisMotorcycle = value; }

    [SerializeField]
    private string date;
    public string Date{ get => Month+"¿ù "+Day+"ÀÏ";
        set => date = value;
    }

    [SerializeField]
    private int day;
    public int Day { get => day; set => day = value; }

    [SerializeField] private int month;
    public int Month { get => month; set => month = value; }
    [SerializeField] private int saveFileNum;
    public int SaveFileNum { get => saveFileNum; set => saveFileNum = value; }
    [SerializeField]
    private int money;
    public int Money { get => money; set => money = value; }

}
