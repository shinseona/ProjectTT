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

}
