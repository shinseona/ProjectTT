using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;
using TMPro;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private UserDataBase udb;
    private PlayerInventoryInfo iteminof;

    public GameObject newgame;
    public GameObject Loadgame;
    public TextMeshProUGUI nameinput;
    public TextMeshProUGUI Dateinput;
    public TextMeshProUGUI moneyinput;
    public GameObject ma;
    public GameObject fe;
    public FadeManager fader;
    public int SaveFileNum;
    private bool isNewGmae;
    private string loadjson;
    private JsonData loadfile;
    public void Start()
    {
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>(); 
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        iteminof = GameObject.Find("ItemInfo").GetComponent<PlayerInventoryInfo>();
        StartCoroutine(fader.FadeOutActiveate(fader));
        FileInfo file = new FileInfo(Application.dataPath + "/Resources/" + "Save" + SaveFileNum + ".json");
        if (file.Exists)
        {
            LoadGame();
        }
        else
        {
            NewGame();
        }
    }

    public void LoadButton()
    {
        //string sceneName = SceneManager.GetActiveScene().name;
        //Param saveData = new Param();
        //saveData.Add("SaveLevel", sceneName);
        //Where saveWhere = new Where();
        //saveWhere.Equal("owner_inDate", udb.UserSeverInDate);
        //string inDate = Backend.GameData.Get("SavePoint", saveWhere).GetInDate();
        //string[] select = {"SaveLevel"};
        //var saveBackend = Backend.GameData.Get("SavePoint", inDate, select);
        //Debug.Log("로딩 되었습니다." + saveBackend.GetReturnValuetoJSON()["row"]["SaveLevel"]["S"]);
        //SceneManager.LoadScene(saveBackend.GetReturnValuetoJSON()["row"]["SaveLevel"]["S"].ToString());
        if (isNewGmae)
        {
            udb.SaveFileNum = SaveFileNum;
            StartCoroutine(fader.FadeInActiveate(fader, "CharacterChoice"));
        } 
        else
        {
            udb.SaveName = loadfile[0]["name"].ToString();
            udb.Day = Int32.Parse(loadfile[0]["day"].ToString())-1;
            udb.Month = Int32.Parse(loadfile[0]["month"].ToString());
            udb.Money = Int32.Parse(loadfile[0]["money"].ToString());
            iteminof.Playercoin = udb.Money;
            if (loadfile[0]["playerGenderMale"].ToString() == "True")
            {
                udb.PlayerGenderMale = true;
            }
            else
            {
                udb.PlayerGenderMale = false;
            }
            udb.SaveFileNum = SaveFileNum;
            StartCoroutine(fader.FadeInActiveate(fader, "step1"));
        }
    }

    public void LoadGame()
    {
        isNewGmae = false;
        Loadgame.SetActive(true);
        loadjson = File.ReadAllText
            (Application.dataPath + "/Resources/" + "Save" + SaveFileNum + ".json");
        loadfile = JsonMapper.ToObject(loadjson);
        nameinput.SetText(loadfile[0]["name"].ToString());
        Dateinput.SetText(loadfile[0]["month"].ToString()+"월 "+loadfile[0]["day"].ToString()+"일");
        moneyinput.SetText(loadfile[0]["money"].ToString());
        if (loadfile[0]["playerGenderMale"].ToString()=="True")
        {
            ma.SetActive(true);
            fe.SetActive(false);
        }
        else
        {
            ma.SetActive(false);
            fe.SetActive(true);
        }

    }

    public void NewGame()
    {
        isNewGmae = true;
        newgame.SetActive(true);
    }

}