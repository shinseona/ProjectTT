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
    public CinemachineVirtualCamera vcam1;
    

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        if (udb.PlayerGenderMale == true)
        {
            male.SetActive(true);
            female.SetActive(false);
            vcam1.Follow = male.transform;
            vcam1.LookAt = male.transform;
        }
        else
        {
            female.SetActive(true);
            male.SetActive(false);
            vcam1.Follow = female.transform;
            vcam1.LookAt = female.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
