using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BushSpawn : BackGroundSpawn
{
    void Start()
    {
        Spawn(4.3f,-1,46);
    }
}
