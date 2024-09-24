using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;

    public void SetPlayerCameraFollow()
    {
        CinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        CinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
    }
}