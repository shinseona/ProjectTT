using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CountScore : MonoBehaviour
{
    public static CountScore Instance { get; private set; }
    private UserDataBase udb;
    public int Score;
    private FadeManager fader;

    public RectTransform ma;
    public RectTransform fe;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        udb = GameObject.Find("UserDataBase").gameObject.GetComponent<UserDataBase>();
        if (udb.PlayerGenderMale)
        {
            ma.gameObject.SetActive(true);
            fe.gameObject.SetActive(false);
        }
        else
        {
            fe.gameObject.SetActive(true);
            ma.gameObject.SetActive(false);
        }
    }

    private void AddScore(int _num)
    {
        Score += _num;
        if (udb.PlayerGenderMale)
        {
            ma.position += new Vector3(3.425f, 0,0);
        }
        else
        {
            fe.position += new Vector3(3.425f, 0, 0);
        }
        if (Score == 200)
        {
            StartCoroutine(fader.FadeInActiveate(fader, "MainGame"));
            //SceneManager.LoadScene("MainGame");
        }
    }
    public static void Static_AddScore(int _num)
    {
        
        Instance.AddScore(_num);
    }
}
