using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiceCheckTrigger : MonoBehaviour
{
	public static Action<int,string> diceRolled;
	Vector3 diceVelocity;
	bool notFoundYetPlayerDice = true;
	bool notFoundYetRivalDice = true;

	// Update is called once per frame
	void FixedUpdate()
	{
		diceVelocity = Dice.diceVelocity;
	}

	
	void OnTriggerStay(Collider col)
	{
		GameObject diceItself = col.gameObject.transform.parent.gameObject;

		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && diceItself.CompareTag("PlayerDice") && notFoundYetPlayerDice)
		{
			switch (col.gameObject.name)
			{
				case "side 1":
					diceRolled.Invoke(6,"PlayerDice");
					notFoundYetPlayerDice = false;
					break;
				case "side 2":
					diceRolled.Invoke(5, "PlayerDice");
					notFoundYetPlayerDice = false;
					break;
				case "side 3":
					diceRolled.Invoke(4, "PlayerDice");
					notFoundYetPlayerDice = false;
					break;
				case "side 4":
					diceRolled.Invoke(3, "PlayerDice");
					notFoundYetPlayerDice = false;
					break;
				case "side 5":
					diceRolled.Invoke(2, "PlayerDice");
					notFoundYetPlayerDice = false;
					break;
				case "side 6":
					diceRolled.Invoke(1, "PlayerDice");
					notFoundYetPlayerDice = false;
					break;

					
			}
	
		}

		else if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && diceItself.CompareTag("RivalDice") && notFoundYetRivalDice)
		{
			switch (col.gameObject.name)
			{
				case "side 1":
					diceRolled.Invoke(6,"RivalDice");
					notFoundYetRivalDice = false;
					break;
				case "side 2":
					diceRolled.Invoke(5,"RivalDice");
					notFoundYetRivalDice = false;
					break;
				case "side 3":
					diceRolled.Invoke(4,"RivalDice");
					notFoundYetRivalDice = false;
					break;
				case "side 4":
					diceRolled.Invoke(3,"RivalDice");
					notFoundYetRivalDice = false;
					break;
				case "side 5":
					diceRolled.Invoke(2,"RivalDice");
					notFoundYetRivalDice = false;
					break;
				case "side 6":
					diceRolled.Invoke(1,"RivalDice");
					notFoundYetRivalDice = false;
					break;


			}

		}



	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//notFoundYet = true;
		}
	}
    /*
    private void OnTriggerEnter(Collider other)
    {
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
		{
			switch (other.gameObject.name)
			{
				case "side 1":
					diceRolled.Invoke(6);
					break;
				case "side 2":
					diceRolled.Invoke(5);
					break;
				case "side 3":
					diceRolled.Invoke(4);
					break;
				case "side 4":
					diceRolled.Invoke(3);
					break;
				case "side 5":
					diceRolled.Invoke(2);
					break;
				case "side 6":
					diceRolled.Invoke(1);
					break;
			}
		}
	}*/
}
