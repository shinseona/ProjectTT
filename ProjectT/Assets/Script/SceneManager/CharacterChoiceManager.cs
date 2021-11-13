using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterChoiceManager : MonoBehaviour
{
    GameObject gameManager;
    UserDataBase udb;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
    }
    public void femaleChoice()
    {
        udb.PlayerGenderMale = false;
        udb.PlayerisMotorcycle = false;
        SceneManager.LoadScene("step1");
    }
    public void maleChoice()
    {
        udb.PlayerGenderMale = true;
        udb.PlayerisMotorcycle = false;
        SceneManager.LoadScene("step1");
    }
}
