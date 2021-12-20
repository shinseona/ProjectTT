using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;
using BackEnd;
public class Opening : MonoBehaviour
{
    public FadeManager fader;
    void Start()
    {
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        StartCoroutine(fader.FadeOutActiveate(fader));
        //SceneManager.LoadScene("Opening");
    }
    public void StartButten()
    {
        StartCoroutine(fader.FadeInActiveate(fader, "ChoiceLoad"));
        //SceneManager.LoadScene("CharacterChoice");
    }
    public void LodeButten()
    {
        BackendReturnObject bro = Backend.BMember.GetUserInfo();
        //Debug.Log(bro.GetReturnValuetoJSON()["row"]["gamerId"]);
    }
    // Update is called once per frame
    public void QuitButten()
    {
        SteamClient.Shutdown();
        ExitGame();
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
