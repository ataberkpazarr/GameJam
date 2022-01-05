using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiceGate : MonoBehaviour
{
    public static Action <Vector3> timeForRollingDice; // the position where dice rolling area will be instantiated will be send as parameter
    private Vector3 positionForDiceArena;

    void Start()
    {
        GameObject positionForDiceArenaObject = transform.GetChild(0).gameObject;
        positionForDiceArena = positionForDiceArenaObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeForRollingDice.Invoke(positionForDiceArena);
        }
    }
}
