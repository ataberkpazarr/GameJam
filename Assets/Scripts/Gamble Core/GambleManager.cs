using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GambleManager : MonoBehaviour
{
    public static Action<float> gambleAnimationHappening;
    
    [SerializeField] private GameObject diceRollArea;
    [SerializeField] private Gamble rollingDice;


    //rock paper Sci
    [SerializeField] private Gamble rockPaperSci;

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
        GiftBoxGate.timeToOpenGiftBox += HandleGiftBoxResult;
    }

    private void OnDisable()
    {
        DiceGate.timeForRollingDice -= doDiceRolling;
        DiceCheckTrigger.diceRolled -= handleRolledDice;
        RockPaperSciGate.timeToPlayRockPaperSci -= PlayRockPaperSci;
        HeadsOrTailsGate.timeToPlayHeadsOrTails -= SpawnHeadsOrTailsCoin;
        HeadOrTailsChecker.coinStopped -= HandleHeadsOrTails;
        GiftBoxGate.timeToOpenGiftBox -= HandleGiftBoxResult;
    }

    private void doDiceRolling(Vector3 vec)
    {
        gambleAnimationHappening.Invoke(3f);
        GameObject g =Instantiate(diceRollArea,vec,Quaternion.identity);
        StartCoroutine(destroyTheDiceArea(g));
    }

    private IEnumerator destroyTheDiceArea(GameObject g)
    {
        yield return new WaitForSeconds(4.5f);
        Destroy(g);
        CameraController.Instance.GoInGameFromDice();

    }

    private void PlayRockPaperSci(Vector3 vec)
    {
        string result = "";

        //GameObject L =Instantiate(leftPersonwithAnim,leftHandSpawnPosition.position ,Quaternion.identity);
        //GameObject R =Instantiate(rightPersonwithAnim, rightHandSpawnPosition.position , Quaternion.identity);

        GameObject L = Instantiate(leftPersonwithAnim, vec, Quaternion.identity);
        GameObject R = Instantiate(rightPersonwithAnim, vec + new Vector3(0.5f,0,0), Quaternion.identity);

        bool notFound = true;
        int leftHand=0, rightHand=0;
        System.Random rnd = new System.Random();
        while (notFound)
        {
  
             leftHand = rnd.Next(0, 3); //includes min excludes max
             rightHand = rnd.Next(0, 3);
            if (rightHand != leftHand && rightHand !=2)
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
                result = "Second";
            }
            else
            {
                //left wins
                result = "First";
            }

           
        }

        else if (rightHand>leftHand)
        {
            if (leftHand == 0 && rightHand == 2)
            {
                //right lose
                result = "First";
            }
            else
            {
                //right wins
                result = "Second";
            }
        }

        gambleAnimationHappening.Invoke(chooseAnimation.length+0.3f);
        StartCoroutine(ShowFinalChoices(leftHand, rightHand, L, R));


        //çalışması lazım
        int coinToAdd = 0;

        if (result == "First")
        {
            coinToAdd += rockPaperSci.BetFirst * rockPaperSci.GainRatio;
        }
        else if (result == "Second")
        {
            coinToAdd += rockPaperSci.BetSecond * rockPaperSci.GainRatio;
        }
        else if (result == "Nope")//eşit gelme durumu
        {
            int coinSpent = rockPaperSci.BetFirst + rockPaperSci.BetSecond;
            CoinManager.Instance.AddCoin(coinSpent);

            //Debug.LogError("geriye odenen: " + coinSpent);
            return;
        }

        Debug.LogError(coinToAdd);
        CoinManager.Instance.AddCoin(coinToAdd);


    }

    private IEnumerator ShowFinalChoices(int i, int k,GameObject L, GameObject R)
    {
        yield return new WaitForSeconds(chooseAnimation.length+0.1f);
        Vector3 vec1 = L.transform.GetChild(0).transform.position;
        Vector3 vec2 = R.transform.GetChild(0).transform.position;

        Destroy(L.gameObject);
        Destroy(R.gameObject);
       
       
        GameObject g = Instantiate(leftOptionsForRockPaperSci[i].gameObject, leftHandSpawnPosition.position + new Vector3(-1.3f,0,0), Quaternion.identity);
        //g.transform.GetChild(0).transform.position = leftHandSpawnPosition.position+new Vector3(-3, 4, 0);
        g.transform.GetChild(0).transform.position = vec1 + new Vector3(-1.2f,0,0);

        //g.transform.GetChild(0).transform.localPosition = leftHandSpawnPosition.position + new Vector3(0, 0, -50);

        GameObject gg =Instantiate(rightOptionsForRockPaperSci[k].gameObject, rightHandSpawnPosition.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
        //gg.transform.GetChild(0).transform.position = rightHandSpawnPosition.position +new Vector3(0,4,0);
        gg.transform.GetChild(0).transform.position = vec2 + new Vector3(0.8f,0,0);

        
        //gg.transform.GetChild(0).transform.localPosition = rightHandSpawnPosition.position + new Vector3(0, 0, -50);



        yield return new WaitForSeconds(1f);

        Destroy(gg);
        Destroy(g);



    }

    
    

    private void handleRolledDice(int i, string s) // zarlar atıldıktan sonra bu method ateşleniyor, i gelen zar s player zar mı rival zar mı o 
    {
        Debug.Log(i.ToString() + " " + s );

        ////////gelen string Nope First ya da Second

        //gerekli total altın azaltma & cogaltma islemi, altın animasyonu vs burada yapılacak ileride


        //CoinManager.AddCoin(amount);
        //CoinManager.RemoveCoin(amount);
        //scale up/down animasyonu için PlayerController bilgilendirilmeli (amount ile)
        //kaybetme kazanma action ı tanımlayabiliriz?

        //-----------------
        //Eğer hangi zarın kazandığı bilgisini buraya getirebilirsen geriye sadece
        //yatırılan paranın kazancını hesaplamak kalacak
        //yukarıda Gamble tipinde rollingDice tanımladım

        //çalışıyor galiba
        int coinToAdd = 0;

        if (s == "First")
        {
            coinToAdd += rollingDice.BetFirst * rollingDice.GainRatio;
        }
        else if(s == "Second")
        {
            coinToAdd += rollingDice.BetSecond * rollingDice.GainRatio;
        }
        else if(s == "Nope")//eşit gelme durumu
        {
            int coinSpent = rollingDice.BetFirst + rollingDice.BetSecond;
            CoinManager.Instance.AddCoin(coinSpent);

            //Debug.LogError("geriye odenen: " + coinSpent);
            return;
        }

        Debug.LogError(coinToAdd);
        CoinManager.Instance.AddCoin(coinToAdd);
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
        Debug.LogError(headsOrTails.PlayerChoice + "  " + result + "  first bet:" + headsOrTails.BetFirst);

        int coinToAdd = 0;

        if(result == "First")
        {
            coinToAdd += headsOrTails.BetFirst * headsOrTails.GainRatio;
        }
        else if(result == "Second")
        {
            coinToAdd += headsOrTails.BetSecond * headsOrTails.GainRatio;
        }
        else if(result == "Nope")// dik gelme durumunda parayı iade ediyoruz???, domuz eski haline dönüyor
        {
            int coinSpent = headsOrTails.BetFirst + headsOrTails.BetSecond;
            CoinManager.Instance.AddCoin(coinSpent);

            //Debug.LogError("geriye odenen: " + coinSpent);
            return;
        }

        Debug.LogError(coinToAdd);
        CoinManager.Instance.AddCoin(coinToAdd);
    }
    #endregion

    #region Gift Box
    private void HandleGiftBoxResult(int giftAmount, GameObject boxRoot, GameObject otherBoxRoot)
    {
        gambleAnimationHappening?.Invoke(2f);
        StartCoroutine(DestroyBoxes(boxRoot, otherBoxRoot));
        // kazanılan paranın eklenmesi
        CoinManager.Instance.AddCoin(giftAmount);
    }

    private IEnumerator DestroyBoxes(GameObject boxRoot, GameObject otherBoxRoot)
    {
        yield return new WaitForSeconds(3f);

        Destroy(boxRoot);
        Destroy(otherBoxRoot);
    }
    #endregion
}
