using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;

public class SaveData
{
    public string name;
    public int month;
    public int day;
    public int money;
    public bool playerGenderMale;

    public SaveData(string _name, int _month, int _day, int _money,bool _playerGenderMale)
    {
        name = _name;
        month = _month;
        money = _money;
        day = _day;
        playerGenderMale = _playerGenderMale;
    }
}
public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private UserDataBase udb;

    public List<SaveData> saveData = new List<SaveData>();

    public void Start()
    {
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();
        saveData.Add(new SaveData(udb.SaveName, udb.Month, udb.Day, udb.Money, udb.PlayerGenderMale));
        JsonData addressJson = JsonMapper.ToJson(saveData);

        File.WriteAllText(Application.dataPath + "/Resources/" + "Save" + udb.SaveFileNum + ".json",
            addressJson.ToString());
    }
    public void SaveButton()
    {
       
        //string sceneName = SceneManager.GetActiveScene().name;
        //Param saveData = new Param();
        //saveData.Add("SaveLevel", sceneName);
        //Where saveWhere = new Where();
        //saveWhere.Equal("owner_inDate", udb.UserSeverInDate);
        //string inDate = Backend.GameData.Get("SavePoint", saveWhere).GetInDate();
        //var saveBackend = Backend.GameData.Update("SavePoint", inDate, saveData);
        //
    }
}
