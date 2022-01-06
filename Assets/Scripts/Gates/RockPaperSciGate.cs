using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RockPaperSciGate : MonoBehaviour
{
    public static Action timeToPlayRockPaperSci; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeToPlayRockPaperSci.Invoke();
        }
    }

}
