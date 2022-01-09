using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cmMenu, cmInGame, cmEndGame, cmGamble;

    private void Start()
    {
        GameManager.Instance.ActionGameStart += SetInGameCamera;
    }

    public void SetInGameCamera()
    {
        cmMenu.enabled = false;
        cmInGame.enabled = true;
    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameStart -= SetInGameCamera;
    }
}
