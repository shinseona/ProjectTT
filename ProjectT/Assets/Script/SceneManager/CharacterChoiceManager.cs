using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterChoiceManager : MonoBehaviour
{
    UserDataBase udb;
    public FadeManager fader;
    public GameObject maB;
    public GameObject feB;

    public GameObject ma;
    public GameObject fe;
    public InputField nameSet;
    private void Start()
    {
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();
        StartCoroutine(fader.FadeOutActiveate(fader));
        maleChoice();
    }


    public void femaleChoice()
    {
        maB.SetActive(false);
        feB.SetActive(true);
        ma.SetActive(false);
        fe.SetActive(true);
        udb.PlayerGenderMale = false;
        udb.PlayerisMotorcycle = false;
        //SceneManager.LoadScene("step1");
    }
    public void maleChoice()
    {

        maB.SetActive(true);
        feB.SetActive(false); 
        ma.SetActive(true);
        fe.SetActive(false);
        udb.PlayerGenderMale = true;
        udb.PlayerisMotorcycle = false; 
        //SceneManager.LoadScene("step1");
    }
    
    public void nextLevel()
    {
        StartCoroutine(fader.FadeInActiveate(fader, "step1"));
        
        udb.Day = 0;
        udb.Month = 1;
        udb.Money = 0;
        udb.SaveName = nameSet.text;
    }

    public void LowLevel()
    {
        StartCoroutine(fader.FadeInActiveate(fader, "ChoiceLoad"));
    }

}
