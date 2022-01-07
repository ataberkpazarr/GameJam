using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetController : MonoBehaviour
{
    [SerializeField] [Tooltip("Kaç saniyede bir bet yapacak?")] private float betDeltaTime = 0.5f;

    private Gamble currentGamble;
    private string currentGate;//  "First"/"Second"

    //tam ortadan geçerse bir bug oluyor
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("First") || other.CompareTag("Second"))
        {
            //(ilk oyun ya da yeni oyun oynanacaksa) ve para varsa
            if ((currentGamble == null
                || (currentGamble != null && other.name != currentGamble.gameObject.name))
                && CoinManager.Instance.CurrentCoin > 0)
            {
                currentGamble = other.gameObject.GetComponentInParent<Gamble>();
                InvokeRepeating("Bet", 0f, betDeltaTime);
            }

            currentGate = other.tag;//yol boyunca sürekli değişebilir  
        }

        if (other.CompareTag("Gate"))//gate e geldiği anda bet işlemi sonlanır
        {
            CancelInvoke("Bet");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("First") || other.CompareTag("Second"))
        {
            if(CoinManager.Instance.CurrentCoin <= 0)// para bittiyse
            {
                CancelInvoke("Bet");
            }
        }
    }

    private void Bet()
    {
        print("bet " + currentGate);
        //şuanki şans oyununun seçeneklerine para yatırma (yazı/tura vs.)
        currentGamble.Bet(currentGate);
    }
}
