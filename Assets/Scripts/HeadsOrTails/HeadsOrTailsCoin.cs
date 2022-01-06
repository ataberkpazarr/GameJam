using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class HeadsOrTailsCoin : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float throwForce = 250f;

    void Start()
    {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        rigidBody.AddForce(transform.up * throwForce, ForceMode.Force);
        rigidBody.AddTorque(dirX, dirY, dirZ);
    }
}
