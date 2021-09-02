using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamCloudInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SteamRemoteStorage.FileWrite("file.txt", );
        foreach (var file in SteamRemoteStorage.Files)
        {
            Debug.Log($"{file} ({SteamRemoteStorage.FileSize(file)} {SteamRemoteStorage.FileTime(file)})");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
