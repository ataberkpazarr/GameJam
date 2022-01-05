using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GambleManager : MonoBehaviour
{
    public static Action<float> gambleAnimationHappening;
    
    [SerializeField] private GameObject diceRollArea;

    
    private void OnEnable()
    {
        DiceGate.timeForRollingDice += doDiceRolling;
        DiceCheckTrigger.diceRolled += handleRolledDice;
    }

    private void OnDisable()
    {
        DiceGate.timeForRollingDice -= doDiceRolling;
        DiceCheckTrigger.diceRolled -= handleRolledDice;
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
  
    private void handleRolledDice(int i, string s) // zarlar atıldıktan sonra bu method ateşleniyor, i gelen zar s player zar mı rival zar mı o 
    {
        Debug.Log(i.ToString() + " " + s );

        //gerekli total altın azaltma & cogaltma islemi, altın animasyonu vs burada yapılacak ileride 

    }
}
