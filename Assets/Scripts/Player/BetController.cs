using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetController : MonoBehaviour
{
    [SerializeField] private Transform pig;

    private Gamble currentGamble;
    private string currentGate;//  "First"/"Second"

    //tam ortadan geçerse bir bug oluyor
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("First") || other.CompareTag("Second"))
        {
            //ilk oyun ya da yeni oyun oynanacak
            if (currentGamble == null
                || (currentGamble != null && other.name != currentGamble.gameObject.name))
            {
                currentGamble = other.gameObject.GetComponentInParent<Gamble>();
                InvokeRepeating("Bet", 0f, 0.5f);
            }

            currentGate = other.tag;//yol boyunca sürekli değişebilir  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("First") || other.CompareTag("Second"))
        {
            //herhangi bir gate ten geçince bet işlemi biter
            //CancelInvoke("Bet");
        }
    }

    private void Bet()
    {
        print("bet " + currentGate);
        //şuanki şans oyununun seçeneklerine para yatırma (yazı/tura vs.)
        currentGamble.Bet(currentGate);
    }

    public void ChangeGamble(Gamble nextGamble)
    {
        currentGamble = nextGamble;
    }
}
