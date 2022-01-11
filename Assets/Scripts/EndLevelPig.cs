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
    private int currentHit = 0;
    private int currentCoinForuUI = 0;

    public static Action timeForConfetti;

    private void Start()
    {
        particleObjectGold = transform.GetChild(5).gameObject;
        pGold = particleObjectGold.GetComponent<ParticleSystem>();

        particleObjectConffeti = transform.GetChild(6).gameObject;
        pConfetti = particleObjectConffeti.GetComponent<ParticleSystem>();

        TotalHit = 4;
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndLevelHammer"))
        {
            if (TotalHit == 0)
            {
                currentHit = currentHit + 1;
                CanvasController.Instance.UpdateMiniGamecoinText(currentCoinForuUI);
            }
            else if (currentHit < TotalHit)
            {
                particleObjectGold.SetActive(true);
                pGold.Play();
                currentHit = currentHit + 1;
                currentCoinForuUI += CoinManager.Instance.CurrentCoin / 4;
                CanvasController.Instance.UpdateMiniGamecoinText(currentCoinForuUI);
            }
            else if (currentHit == TotalHit)
            {
                timeForConfetti.Invoke();
                particleObjectConffeti.SetActive(true);
                pConfetti.Play();
                GameManager.Instance.ActionGameOver?.Invoke();
            }
        }
        
    }
}
