using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct ScreenSize
{
    public int width { get; set; }
    public int height { get; set; }
};

public class MenuMangaer : MonoBehaviour
{
    public GameObject MenuTap;
    FullScreenMode screenMode;
    public List<Resolution> resolution = new List<Resolution>();//호환 가능 화면 크기 저장
    public List<ScreenSize> screenSizes = new List<ScreenSize>();
    public List<int> resolution_hz = new List<int>();
    public FadeManager fader;
    public int sizeOptionNum;
    public int resolutionNum;
    private void Awake()
    {
        //resolution.AddRange(Screen.resolutions);
        //resolution = resolution.ToList();
        //for (int i = 0; i < resolution.Count; i++)
        //{
        //    if (resolution[i].width > 1919)
        //    {
        //        ScreenSize c = new ScreenSize();
        //        c.width = resolution[i].width;
        //        c.height = resolution[i].height;

        //        screenSizes.Add(c);
        //        if (resolution[i].width == Screen.width && resolution[i].height == Screen.height)
        //        {
        //            sizeOptionNum = i;
        //        }
        //    }
        //}
        //screenSizes = screenSizes.ToList();
    }

    void Start()
    {

        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
    }
    public void DropboxOptionChange(int _optionNum)
    {
        resolutionNum = _optionNum;
    }
    public void MenuConfirm()
    {
        MenuTap.SetActive(false);
    }
    public void FullScreenChange(bool _isFull)
    {
        screenMode = _isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void StartMenu()
    {
        MenuTap.SetActive(!MenuTap.activeSelf);
    }
    public void StopMenu()
    {
        MenuTap.SetActive(false);
    }

    public void GoHome()
    {
        StartCoroutine(fader.FadeInActiveate(fader, "Opening"));
    }
}
