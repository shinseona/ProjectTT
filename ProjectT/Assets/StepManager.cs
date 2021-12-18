using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class StepManager : MonoBehaviour
{
    public static StepManager instance { get; private set; }

    [SerializeField]
    private RectTransform canvasRectTransform = null;

    [SerializeField]
    private GameObject itemToolTip;
    private RectTransform itemToolTipRectTransform;
    private TextMeshProUGUI itemNameNum;
    private TextMeshProUGUI addressNum;
    private TextMeshProUGUI npcNameNum;
    private TextMeshProUGUI weightNum;
    private bool ishide;
    public FadeManager fader;
    public bool step1 =false;
    UserDataBase udb;
    void Awake()
    {
        instance = this;
        itemToolTipRectTransform = itemToolTip.GetComponent<RectTransform>();
        itemNameNum = itemToolTip.transform.Find("ItemNameNum").GetComponent<TextMeshProUGUI>();
        addressNum = itemToolTip.transform.Find("AddressNum").GetComponent<TextMeshProUGUI>();
        npcNameNum = itemToolTip.transform.Find("NPCNameNum").GetComponent<TextMeshProUGUI>();
        weightNum = itemToolTip.transform.Find("WeightNum").GetComponent<TextMeshProUGUI>();
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();
    }

    void Start()
    {
        itemToolTip.SetActive(false);
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        StartCoroutine(fader.FadeOutActiveate(fader));
        if (step1)
        {

            udb.Day += 1;
            if (udb.Day > 28)
            {
                udb.Month += 1;
                udb.Day = 1;
            }
        }
    }

    void Update()
    {
        if (ishide&&itemToolTip.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                ToolSetActive();
                StartCoroutine(hideTime());
            }
        }
    }

    private void ToolSetActive()
    {
        itemToolTip.SetActive(!itemToolTip.activeSelf);
    }
    private void ShowTool(string _itemNameNum,string _addressNum, string _npcNameNum,string _weightNum)
    {
        itemNameNum.text = _itemNameNum;
        addressNum.text = _addressNum;
        npcNameNum.text = _npcNameNum;
        weightNum.text = _weightNum;
        ToolSetActive();
        StartCoroutine(hideTime());
    }

    public static void ShowTool_static(string _itemNameNum, string _addressNum, string _npcNameNum, string _weightNum)
    {
        instance.ShowTool(_itemNameNum, _addressNum, _npcNameNum, _weightNum);
    }
    
    private bool ToolActive()
    {
        return itemToolTip.activeSelf;
    }
    public static bool ToolActive_static()
    {
        return instance.ishide;
    }

    IEnumerator hideTime()
    {
        yield return new WaitForSeconds(0.2f);
        ishide = ToolActive();
    }
}

