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
        float dirX = Random.Range(-500, 500);
        float dirY = Random.Range(-500, 500);
        float dirZ = Random.Range(-500, 500);
        rigidBody.AddForce(transform.up * throwForce);
        rigidBody.AddTorque(dirX, dirY, dirZ);
    }
}
