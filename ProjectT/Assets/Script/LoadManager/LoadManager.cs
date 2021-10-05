using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField]
    private UserDataBase udb;
    public void LoadButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Param saveData = new Param();
        saveData.Add("SaveLevel", sceneName);
        Where saveWhere = new Where();
        saveWhere.Equal("owner_inDate", udb.UserSeverInDate);
        string inDate = Backend.GameData.Get("SavePoint", saveWhere).GetInDate();
        string[] select = { "SaveLevel" };
        var saveBackend = Backend.GameData.Get("SavePoint", inDate, select);
        Debug.Log("로딩 되었습니다." + saveBackend.GetReturnValuetoJSON()["row"]["SaveLevel"]["S"]);
        SceneManager.LoadScene(saveBackend.GetReturnValuetoJSON()["row"]["SaveLevel"]["S"].ToString());

    }
}