using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerChoice : MonoBehaviour
{
    GameObject gameManager;
    UserDataBase udb;
    public GameObject female;
    public GameObject male;
    public MainPlayerCamera vcam;
    

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        vcam = gameObject.GetComponent<MainPlayerCamera>();
        if (udb.PlayerGenderMale == true)
        {
            male.SetActive(true);
            female.SetActive(false);
            vcam.ControlCam( male.transform);
        }
        else
        {
            female.SetActive(true);
            male.SetActive(false);
            vcam.ControlCam(female.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
