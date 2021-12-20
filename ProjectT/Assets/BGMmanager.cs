using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMmanager : MonoBehaviour
{
    public AudioSource bgm;
    public List<AudioClip> bgmClip; 
    // Start is called before the first frame update
    void Start()
    {
        bgm = this.gameObject.GetComponent<AudioSource>();
        if (bgm.isPlaying) return;
        else
        {
            bgm.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Opening")
        {
            if (bgm.clip != bgmClip[0])
            {
                bgm.clip = bgmClip[0];
                bgm.Play();
            }
        }
        else if(SceneManager.GetActiveScene().name == "CharacterChoice"||
                SceneManager.GetActiveScene().name == "ChoiceLoad")
        {
            if (bgm.clip != bgmClip[1])
            {
                bgm.clip = bgmClip[1];
                bgm.Play();
            }
        }
        else if(SceneManager.GetActiveScene().name =="step1")
        {
            if (bgm.clip != bgmClip[2])
            {
                bgm.clip = bgmClip[2];
                bgm.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "GridGame")
        {
            if (bgm.clip != bgmClip[3])
            {
                bgm.clip = bgmClip[3];
                bgm.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "MainGame")
        {
            if (bgm.clip != bgmClip[4])
            {
                bgm.clip = bgmClip[4];
                bgm.Play();
            }
        }
    }
}
