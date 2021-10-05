using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetUpSceneManager : MonoBehaviour
{

    void Start()
    {
        SceneManager.LoadScene("Opening");
    }

}
