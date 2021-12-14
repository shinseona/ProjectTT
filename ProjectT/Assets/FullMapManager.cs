using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMapManager : MonoBehaviour
{
    public GameObject MapObj;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            MapObj.SetActive(!MapObj.activeSelf);
        }
    }
}
