using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Steamworks;

class PlayerData 
{
    public bool PlayerGender;

    public PlayerData(bool playerGender)
    {
        PlayerGender = playerGender;
        
    }
}
public class SavePlayerData : MonoBehaviour
{
    public UserDataBase udb;
    PlayerData p1;
   
    // Start is called before the first frame update
    void Start()
    {
        SavePlayer();
    }
    public void SavePlayer()
    {
        p1 = new PlayerData(udb.PlayerGenderMale);
        string tojosn = JsonUtility.ToJson(p1);
        Debug.Log("클라우드 활성화 :" +SteamRemoteStorage.QuotaBytes);
        Debug.Log(SteamRemoteStorage.FileWrite("test.json", Encoding.UTF8.GetBytes(tojosn)));
        Debug.Log(SteamRemoteStorage.FileCount);
        foreach (var file in SteamRemoteStorage.Files)
        {
            Debug.Log("파일");
            Debug.Log($"{file} ({SteamRemoteStorage.FileSize(file)} {SteamRemoteStorage.FileTime(file)})");
        }
        //var a = SteamRemoteStorage.FileRead("test.json");
        //string a = File.ReadAllText(Application.dataPath + "/Save/test.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
