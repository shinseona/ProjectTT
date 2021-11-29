using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGameManager : MonoBehaviour
{
    public FadeManager fader;
    void Start()
    {
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        StartCoroutine(fader.FadeOutActiveate(fader));
        //SceneManager.LoadScene("Opening");
    }
}
