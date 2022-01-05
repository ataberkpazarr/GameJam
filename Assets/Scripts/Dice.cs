using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	static Rigidbody rb;
	public static Vector3 diceVelocity;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		float dirX = Random.Range(0, 500);
		float dirY = Random.Range(0, 500);
		float dirZ = Random.Range(0, 500);
		transform.rotation = Quaternion.identity;
		rb.AddForce(transform.up * 500);
		rb.AddTorque(dirX, dirY, dirZ);
	}

	// Update is called once per frame
	void Update()
	{
		
		diceVelocity = rb.velocity;
	
	}
}
