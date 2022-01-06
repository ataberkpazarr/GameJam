using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsOrTailsGate : MonoBehaviour
{
    [SerializeField] private Gamble gamble;

    public static Action<Vector3> timeToPlayHeadsOrTails;
    [SerializeField] private Transform coinPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !gamble.Activated)
        {
            gamble.Activated = true;
            gamble.PlayerChoice = gameObject.name;// root a player ın seçimi bildirilir
            timeToPlayHeadsOrTails?.Invoke(coinPos.position);
        }
    }
}
