using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private CinemachineVirtualCamera cmMenu, cmInGame, cmEndGame, cmDice,cmConfetti;




    private void OnEnable()
    {

        GameManager.Instance.ActionGameStart += SetInGameCamera;
        PlayerController.ReachedEndOfLevel += SetEndCamera;
        EndLevelPig.timeForConfetti += SpawnConfetti;
        DiceGate.timeForRollingDice += GoDiceCamera;
    }

    public void GoInGameFromDice()
    {

        cmDice.enabled = false;
        cmInGame.enabled = true;
    }
    private void GoDiceCamera(Vector3 vec)
    {
        cmInGame.enabled = false;
        cmDice.enabled = true;

    }
    public void SetInGameCamera()
    {
        cmMenu.enabled = false;
        cmInGame.enabled = true;
    }

    private void SetEndCamera()
    {
        cmInGame.enabled = false;
        cmEndGame.enabled = true;

    }

    private void SpawnConfetti()
    {

        cmEndGame.enabled = false;
        cmConfetti.enabled = true;
    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameStart -= SetInGameCamera;
        PlayerController.ReachedEndOfLevel -= SetEndCamera;
        EndLevelPig.timeForConfetti -= SpawnConfetti;
        DiceGate.timeForRollingDice -= GoDiceCamera;


    }
}
