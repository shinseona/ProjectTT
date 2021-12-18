using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BackEnd;

public class SaveData
{
    public string name;
    public string SceneName;
    public string Date;
    public int money;

    public SaveData(string _name, string _sceneName, string _date, int _money)
    {
        name = _name;
        SceneName = _sceneName;
        Date = _date;
        money = _money;
    }
}
public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private UserDataBase udb;
    public void SaveButton()
    {
        SaveData()
        //string sceneName = SceneManager.GetActiveScene().name;
        //Param saveData = new Param();
        //saveData.Add("SaveLevel", sceneName);
        //Where saveWhere = new Where();
        //saveWhere.Equal("owner_inDate", udb.UserSeverInDate);
        //string inDate = Backend.GameData.Get("SavePoint", saveWhere).GetInDate();
        //var saveBackend = Backend.GameData.Update("SavePoint", inDate, saveData);
        //Debug.Log("저장되었습니다.");
    }
}
