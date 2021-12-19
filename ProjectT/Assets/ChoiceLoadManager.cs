using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceLoadManager : MonoBehaviour
{
    public Button GoingHome;
    MenuMangaer menuManger;
    private void Start()
    {
        menuManger = GameObject.Find("MenuManager").GetComponent<MenuMangaer>();
        GoingHome.onClick.AddListener(menuManger.GoHome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
