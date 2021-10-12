using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MainPlayerCamera : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;
    public void ControlCam(Transform PlayerPoint)
    {
        vcam1.Follow = PlayerPoint;
        vcam1.LookAt = PlayerPoint;
    }
}
