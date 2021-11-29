using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterChoiceManager : MonoBehaviour
{
    GameObject gameManager;
    UserDataBase udb;
    public FadeManager fader;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        StartCoroutine(fader.FadeOutActiveate(fader));
    }
    public void femaleChoice()
    {
        udb.PlayerGenderMale = false;
        udb.PlayerisMotorcycle = false;
        StartCoroutine(fader.FadeInActiveate(fader, "step1"));
        //SceneManager.LoadScene("step1");
    }
    public void maleChoice()
    {
        udb.PlayerGenderMale = true;
        udb.PlayerisMotorcycle = false;
        StartCoroutine(fader.FadeInActiveate(fader, "step1"));
        //SceneManager.LoadScene("step1");
    }
}
