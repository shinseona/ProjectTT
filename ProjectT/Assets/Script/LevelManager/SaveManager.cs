using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BackEnd;
public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private UserDataBase udb;
    public void SaveButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Param saveData = new Param();
        saveData.Add("SaveLevel", sceneName);
        Where saveWhere = new Where();
        saveWhere.Equal("owner_inDate", udb.UserSeverInDate);
        string inDate = Backend.GameData.Get("SavePoint", saveWhere).GetInDate();
        var saveBackend = Backend.GameData.Update("SavePoint", inDate, saveData);
        Debug.Log("저장되었습니다.");
    }
}
