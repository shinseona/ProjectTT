using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonController : MonoBehaviour
{
    [Header("Opening")]
    public Button openingLoding;
    public Button openingMenuStart;
    public Button openingMenuStop;
    public Button openingMenuConfirm;
    public GameObject openingMenuTap;

    [Header("CharacterChoice")]
    public Button feMaleChoice;
    public Button maleChoice;

    [Header("step1")]
    public Button stepOneSave;
    public Button stepOneMenuStart;
    public Button stepOneMenuStop;
    public Button stepOneMenuConfirm;
    public GameObject stepOneMenuTap;
    public Button GoingHome;

    GameObject gameManager;
    MenuMangaer menuManger;
    private BGMmanager bgmManager;
    public Toggle BGMmute;
    public Slider BGMNum;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        menuManger = gameManager.transform.GetChild(4).GetComponent<MenuMangaer>();
        bgmManager = GameObject.Find("BGMmanager").GetComponent<BGMmanager>();

        BGMNum.value= bgmManager.bgm.volume;
        BGMmute.isOn = !bgmManager.bgm.mute;
        if (SceneManager.GetActiveScene().name == "Opening")
        {
            Opening();
        }

        if (SceneManager.GetActiveScene().name == "step1"||
            SceneManager.GetActiveScene().name == "MainGame")
        {
            StepOne();
        }
  
    }

    //public void WinSizeUP()
    //{
    //    if (menuManger.sizeOptionNum < menuManger.screenSizes.Count-1)
    //    {
    //        menuManger.sizeOptionNum += 1;
    //    }
    //    else
    //    {
    //        menuManger.sizeOptionNum = 0;

    //    }

    //    WinSizeText.SetText(menuManger.screenSizes[menuManger.sizeOptionNum].width.ToString() + "X" +
    //                        menuManger.screenSizes[menuManger.sizeOptionNum].height.ToString());
    //}
    //public void WinSizeDown()
    //{
    //    if (menuManger.sizeOptionNum > 0)
    //    {
    //        menuManger.sizeOptionNum -= 1;
    //    }
    //    else
    //    {
    //        menuManger.sizeOptionNum = menuManger.screenSizes.Count-1;

    //    }

    //    WinSizeText.SetText(menuManger.screenSizes[menuManger.sizeOptionNum].width.ToString() + "X" +
    //                        menuManger.screenSizes[menuManger.sizeOptionNum].height.ToString());
    //}
    private void Opening()
    {
        menuManger.MenuTap = openingMenuTap;
        
        openingMenuStart.onClick.AddListener(menuManger.StartMenu);
        openingMenuStop.onClick.AddListener(menuManger.StopMenu);
        openingMenuConfirm.onClick.AddListener(menuManger.MenuConfirm);

    }
    private void StepOne()
    {
        menuManger.MenuTap = stepOneMenuTap;
        
        stepOneMenuStart.onClick.AddListener(menuManger.StartMenu);
        stepOneMenuStop.onClick.AddListener(menuManger.StopMenu);
        stepOneMenuConfirm.onClick.AddListener(menuManger.MenuConfirm);
        GoingHome.onClick.AddListener(menuManger.GoHome);

    }

    public void BgmSet()
    {
        bgmManager.bgm.mute = !BGMmute.isOn;
    }

    public void BgmSoundPower()
    {
        bgmManager.bgm.volume = BGMNum.value;
    }
}
