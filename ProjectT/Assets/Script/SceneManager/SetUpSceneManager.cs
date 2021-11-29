using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetUpSceneManager : MonoBehaviour
{
    public FadeManager fader;
    void Start()
    {
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        StartCoroutine(fader.FadeInActiveate(fader, "Opening"));
        //SceneManager.LoadScene("Opening");
    }

}
