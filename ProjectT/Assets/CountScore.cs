using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CountScore : MonoBehaviour
{
    public static CountScore Instance { get; private set; }
    [SerializeField]
    private TextMeshProUGUI reScoreText;
    public int Score;
    private FadeManager fader;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
         
    }

    private void Start()
    {
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        reScoreText.text = Score.ToString();
    }

    private void AddScore(int _num)
    {
        Score += _num;
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
