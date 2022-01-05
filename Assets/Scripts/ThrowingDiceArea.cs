using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDiceArea : MonoBehaviour
{
    private GameObject playerDice;
    private GameObject rivalDice;

    void Start() 
    {
         playerDice = gameObject.transform.GetChild(6).gameObject;
         rivalDice = gameObject.transform.GetChild(7).gameObject;

        

        Invoke("CreateDices",0.5f); // dice arena olusturulduktan yarım saniye sonra atılacak zarları olusturuyor

    }

    private void CreateDices()
    {

        playerDice.SetActive(true);
        rivalDice.SetActive(true);

    }
}
