using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GambleManager : MonoBehaviour
{
    public static Action<float> gambleAnimationHappening;
    
    [SerializeField] private GameObject diceRollArea;


    //rock paper Sci

    [SerializeField] private Transform rightHandSpawnPosition;
    [SerializeField] private Transform leftHandSpawnPosition;


    [SerializeField] private GameObject rightPersonwithAnim;
    [SerializeField] private GameObject leftPersonwithAnim;

    [SerializeField] private AnimationClip chooseAnimation;


    [SerializeField] private List<GameObject> rightOptionsForRockPaperSci;
    [SerializeField] private List<GameObject> leftOptionsForRockPaperSci;


    //heads or tails
    [SerializeField] private GameObject headsOrTailsCoin;
    [SerializeField] private Gamble headsOrTails;// her şans oyununun root objesine tanımlanır
    // player'ın seçimini, ne kadar yatırdığını vs. buradan öğrenebiliriz.


    private void OnEnable()
    {
        DiceGate.timeForRollingDice += doDiceRolling;
        DiceCheckTrigger.diceRolled += handleRolledDice;
        RockPaperSciGate.timeToPlayRockPaperSci += PlayRockPaperSci;
        HeadsOrTailsGate.timeToPlayHeadsOrTails += SpawnHeadsOrTailsCoin;
        HeadOrTailsChecker.coinStopped += HandleHeadsOrTails;
    }

    private void OnDisable()
    {
        DiceGate.timeForRollingDice -= doDiceRolling;
        DiceCheckTrigger.diceRolled -= handleRolledDice;
        RockPaperSciGate.timeToPlayRockPaperSci -= PlayRockPaperSci;
        HeadsOrTailsGate.timeToPlayHeadsOrTails -= SpawnHeadsOrTailsCoin;
        HeadOrTailsChecker.coinStopped -= HandleHeadsOrTails;
    }

    private void doDiceRolling(Vector3 vec)
    {
        gambleAnimationHappening.Invoke(3f);
        GameObject g =Instantiate(diceRollArea,vec,Quaternion.identity);
        StartCoroutine(destroyTheDiceArea(g));
    }

    private IEnumerator destroyTheDiceArea(GameObject g)
    {
        yield return new WaitForSeconds(5f);
        Destroy(g);

    }

    private void PlayRockPaperSci()
    {

        GameObject L =Instantiate(leftPersonwithAnim,leftHandSpawnPosition.position ,Quaternion.identity);
        GameObject R =Instantiate(rightPersonwithAnim, rightHandSpawnPosition.position , Quaternion.identity);
        bool notFound = true;
        int leftHand=0, rightHand=0;
        System.Random rnd = new System.Random();
        while (notFound)
        {
  
             leftHand = rnd.Next(0, 3); //includes min excludes max
             rightHand = rnd.Next(0, 3);
            if (rightHand != leftHand)
            {
                notFound = false;
            }

        }
        //2 for Sci 1 for paper 0 for rock
        if (leftHand >rightHand)
        {
            if (rightHand == 0 && leftHand == 2)
            {
                //left lose
            }
            else
            {
                //left wins
            }

           
        }

        else if (rightHand>leftHand)
        {
            if (leftHand == 0 && rightHand == 2)
            {
                //right lose
            }
            else
            {
                //right wins
            }
        }

        gambleAnimationHappening.Invoke(chooseAnimation.length+0.3f);
        StartCoroutine(ShowFinalChoices(leftHand, rightHand, L, R));
        



    }

    private IEnumerator ShowFinalChoices(int i, int k,GameObject L, GameObject R)
    {
        yield return new WaitForSeconds(chooseAnimation.length+0.1f);
        Destroy(L.gameObject);
        Destroy(R.gameObject);
       
       
        Instantiate(leftOptionsForRockPaperSci[i].gameObject, leftHandSpawnPosition.position + new Vector3(-1.3f,0,0), Quaternion.identity);
        Instantiate(rightOptionsForRockPaperSci[k].gameObject, rightHandSpawnPosition.position + new Vector3(1.5f, 0, 0), Quaternion.identity);

        yield return new WaitForSeconds(0.2f);



    }

    private void handleRolledDice(int i, string s) // zarlar atıldıktan sonra bu method ateşleniyor, i gelen zar s player zar mı rival zar mı o 
    {
        Debug.Log(i.ToString() + " " + s );

        //gerekli total altın azaltma & cogaltma islemi, altın animasyonu vs burada yapılacak ileride


        //CoinManager.AddCoin(amount);
        //CoinManager.RemoveCoin(amount);
        //scale up/down animasyonu için PlayerController bilgilendirilmeli (amount ile)
        //kaybetme kazanma action ı tanımlayabiliriz?
    }

    #region HeadsOrTails
    private void SpawnHeadsOrTailsCoin(Vector3 coinPos)
    {
        gambleAnimationHappening?.Invoke(3f);
        GameObject coin = Instantiate(headsOrTailsCoin, coinPos, Quaternion.identity);
        StartCoroutine(DestroyCoin(coin));
    }

    private IEnumerator DestroyCoin(GameObject coin)
    {
        yield return new WaitForSeconds(5f);
        Destroy(coin);
    }

    private void HandleHeadsOrTails(string result)
    {
        Debug.LogError(headsOrTails.PlayerChoice + "  " + result);

        // player ın seçimi ile result karşılaştırılır ve altın işlemleri yapılır.
    }
    #endregion
}
