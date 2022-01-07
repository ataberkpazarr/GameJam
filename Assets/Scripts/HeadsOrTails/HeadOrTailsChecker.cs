using System;
using UnityEngine;

public class HeadOrTailsChecker : MonoBehaviour
{
    public static Action<string> coinStopped;

    [SerializeField] private Rigidbody parentRigidbody;
    private bool resultChecked = false;

    private void OnTriggerStay(Collider other)
    {
        if(parentRigidbody.velocity == Vector3.zero && other.CompareTag("Parkour") && !resultChecked)
        {
            string result = "";

            if (gameObject.name == "Heads")
                result = "First";
            else if (gameObject.name == "Tails")
                result = "Second";
            else if(gameObject.name == "Nope")// dik gelme durumu
                result = "Nope";

            resultChecked = true;
            coinStopped?.Invoke(result);
        }
    }
}
