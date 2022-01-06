using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//her iki yüzey için
public class HeadOrTailsChecker : MonoBehaviour
{
    [SerializeField] private HeadsOrTailsGate gate;

    public static Action<string> coinStopped;

    [SerializeField] private Rigidbody parentRigidbody;
    private bool resultChecked = false;

    private void OnTriggerStay(Collider other)
    {
        if(parentRigidbody.velocity == Vector3.zero && other.CompareTag("Parkour") && !resultChecked)
        {
            string result;

            if (gameObject.name == "Heads")
                result = "Tails";
            else
                result = "Heads";

            coinStopped?.Invoke(result);
            resultChecked = true;
        }
    }
}
