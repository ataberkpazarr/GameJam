using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndLevelPig : MonoBehaviour
{
    private GameObject particleObjectGold;
    private GameObject particleObjectConffeti;

    ParticleSystem pGold;
    ParticleSystem pConfetti;

    private int TotalHit=0;

    public static Action timeForConfetti;
    private void Start()
    {
         particleObjectGold = transform.GetChild(5).gameObject;
         pGold = particleObjectGold.GetComponent<ParticleSystem>();

        particleObjectConffeti = transform.GetChild(6).gameObject;
        pConfetti = particleObjectConffeti.GetComponent<ParticleSystem>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (TotalHit ==0)
        {
            TotalHit = TotalHit + 1;
        }
        else if (TotalHit<4)
        {
            particleObjectGold.SetActive(true);
            pGold.Play();
            TotalHit = TotalHit + 1;
        }

        else if (TotalHit >=4)
        {
            timeForConfetti.Invoke();
            particleObjectConffeti.SetActive(true);
            pConfetti.Play();
        }
    }
}
