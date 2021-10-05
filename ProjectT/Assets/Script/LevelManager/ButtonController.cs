using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    [Header("Opening")]
    public Button openingLoding;
    public Button openingMenuStart;
    public Button openingMenuStop;
    public Dropdown openingResolutionDropDown;
    public Toggle openingFullscreenButten;
    public Button openingMenuConfirm;
    public GameObject openingMenuTap;

    [Header("CharacterChoice")]
    public Button feMaleChoice;
    public Button maleChoice;

    [Header("step1")]
    public Button stepOneSave;
    public Button stepOneMenuStart;
    public Button stepOneMenuStop;
    public Dropdown stepOneResolutionDropDown;
    public Toggle stepOneFullscreenButten;
    public Button stepOneMenuConfirm;
    public GameObject stepOneMenuTap;

    GameObject gameManager;
    SaveManager saveManager;
    LoadManager loadManager;
    MenuMangaer menuManger;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        saveManager = gameManager.transform.GetChild(3).GetComponent<SaveManager>();
        loadManager = gameManager.transform.GetChild(3).GetComponent<LoadManager>();
        menuManger = gameManager.transform.GetChild(4).GetComponent<MenuMangaer>();

        if (SceneManager.GetActiveScene().name == "Opening")
        {
            Opening();
        }

        if (SceneManager.GetActiveScene().name == "step1")
        {
            StepOne();
        }
  
    }
    private void Opening()
    {
        menuManger.MenuTap = openingMenuTap;

        openingLoding.onClick.AddListener(loadManager.LoadButton);
        openingMenuStart.onClick.AddListener(menuManger.StartMenu);
        openingMenuStop.onClick.AddListener(menuManger.StopMenu);
        openingResolutionDropDown.onValueChanged.AddListener(menuManger.DropboxOptionChange);
        openingFullscreenButten.onValueChanged.AddListener(menuManger.FullScreenChange);
        openingMenuConfirm.onClick.AddListener(menuManger.MenuConfirm);

        openingResolutionDropDown.options.Clear();
        int optionNum = 0;
        foreach(ScreenSize item in menuManger.screenSizes)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height;
            //option.text = item.width + "x" + item.height+ " "+item.refreshRate+"hz";
            openingResolutionDropDown.options.Add(option);
            if(item.width == Screen.width&&item.height==Screen.height)
            {
                openingResolutionDropDown.value = optionNum;
            }
            optionNum++;
        }
        openingResolutionDropDown.RefreshShownValue();
        openingFullscreenButten.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
        
        Debug.Log("오프닝 버튼 초기화");
    }
    private void StepOne()
    {
        menuManger.MenuTap = stepOneMenuTap;

        stepOneSave.onClick.AddListener(saveManager.SaveButton);
        stepOneMenuStart.onClick.AddListener(menuManger.StartMenu);
        stepOneMenuStop.onClick.AddListener(menuManger.StopMenu);
        stepOneResolutionDropDown.onValueChanged.AddListener(menuManger.DropboxOptionChange);
        stepOneFullscreenButten.onValueChanged.AddListener(menuManger.FullScreenChange);
        stepOneMenuConfirm.onClick.AddListener(menuManger.MenuConfirm);

        stepOneResolutionDropDown.options.Clear();
        int optionNum = 0;
        foreach (ScreenSize item in menuManger.screenSizes)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height;
            //option.text = item.width + "x" + item.height+ " "+item.refreshRate+"hz";
            stepOneResolutionDropDown.options.Add(option);
            if (item.width == Screen.width && item.height == Screen.height)
            {
                stepOneResolutionDropDown.value = optionNum;
            }
            optionNum++;
        }
        stepOneResolutionDropDown.RefreshShownValue();
        stepOneFullscreenButten.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;

        Debug.Log("1번 씬 버튼 초기화");
    }
}
