using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameTime : MonoBehaviour
{
    private int mi=0;
    private int se=0;
    float deltaTime = 0;
    [SerializeField]
    private TextMeshProUGUI Mil;
    [SerializeField]
    private TextMeshProUGUI Sec;
    private PlayerInventoryInfo iteminof;
    private GameObject gameManager;
    UserDataBase udb;
    public FadeManager fader;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject;
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        iteminof = gameManager.transform.GetChild(5).GetComponent<PlayerInventoryInfo>();

    }
    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > 1)
        {
            se += 1;
            deltaTime = 0;
        }

        if (se == 60)
        {
            mi += 1;
            se = 0;
        }
        Sec.SetText(se.ToString());
        Mil.SetText(mi.ToString());
        if (mi == 5)
        {
            iteminof.itemList = new List<ItemInfo>();
            udb.PlayerisMotorcycle = false;
            udb.Money = iteminof.Playercoin;
            StartCoroutine(fader.FadeInActiveate(fader, "step1"));
        }
        else if (iteminof.itemList.Count ==0) 
        {
            iteminof.itemList = new List<ItemInfo>();
            udb.PlayerisMotorcycle = false;
            udb.Money = iteminof.Playercoin;
            StartCoroutine(fader.FadeInActiveate(fader, "step1"));
        }
    }
}
