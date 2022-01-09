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
	bool playerDiceDone = false;
	bool rivalDiceDone = false;

	int leftDiceResult = 0;
	int rightDiceResult = 0;

	// Update is called once per frame
	void FixedUpdate()
	{
		diceVelocity = Dice.diceVelocity;
	}

	
	void OnTriggerStay(Collider col)
	{
		GameObject diceItself = col.gameObject.transform.parent.gameObject;
		//if i kısalttım
		if (diceVelocity == Vector3.zero && diceItself.CompareTag("PlayerDice") && notFoundYetPlayerDice)
		{
			switch (col.gameObject.name)
			{
				case "side 1":
					//diceRolled.Invoke(6,"PlayerDice");
					leftDiceResult = 6;
					notFoundYetPlayerDice = false;
					 playerDiceDone = true;
					break;
				case "side 2":
					//diceRolled.Invoke(5, "PlayerDice");
					leftDiceResult = 5;
					notFoundYetPlayerDice = false;
					playerDiceDone = true;
					break;
				case "side 3":
					//diceRolled.Invoke(4, "PlayerDice");
					leftDiceResult = 4;
					notFoundYetPlayerDice = false;
					playerDiceDone = true;
					break;
				case "side 4":
					//diceRolled.Invoke(3, "PlayerDice");
					leftDiceResult = 3;
					notFoundYetPlayerDice = false;
					playerDiceDone = true;
					break;
				case "side 5":
					//diceRolled.Invoke(2, "PlayerDice");
					leftDiceResult = 2;
					notFoundYetPlayerDice = false;
					playerDiceDone = true;
					break;
				case "side 6":
					//diceRolled.Invoke(1, "PlayerDice");
					leftDiceResult = 1;
					notFoundYetPlayerDice = false;
					playerDiceDone = true;
					break;

					
			}
	
		}

		else if (diceVelocity == Vector3.zero && diceItself.CompareTag("RivalDice") && notFoundYetRivalDice)
		{
			switch (col.gameObject.name)
			{
				case "side 1":
					//diceRolled.Invoke(6,"RivalDice");
					rightDiceResult = 6;
					notFoundYetRivalDice = false;
					rivalDiceDone = true;
					break;
				case "side 2":
					//diceRolled.Invoke(5,"RivalDice");
					rightDiceResult = 5;
					notFoundYetRivalDice = false;
					rivalDiceDone = true;
					break;
				case "side 3":
					//diceRolled.Invoke(4,"RivalDice");
					rightDiceResult = 4;
					notFoundYetRivalDice = false;
					rivalDiceDone = true;
					break;
				case "side 4":
					//diceRolled.Invoke(3,"RivalDice");
					rightDiceResult = 3;
					notFoundYetRivalDice = false;
					rivalDiceDone = true;
					break;
				case "side 5":
					//diceRolled.Invoke(2,"RivalDice");
					rightDiceResult = 2;
					notFoundYetRivalDice = false;
					rivalDiceDone = true;
					break;
				case "side 6":
					//diceRolled.Invoke(1,"RivalDice");
					rightDiceResult = 1;
					notFoundYetRivalDice = false;
					rivalDiceDone = true;
					break;


			}

		}



	}

	private void Update()
	{
        if (playerDiceDone&&rivalDiceDone)
        {
            if (leftDiceResult>rightDiceResult)
            {
				diceRolled.Invoke(0,"First");
            }

            else if (rightDiceResult>leftDiceResult)
            {
				diceRolled.Invoke(0, "Second");

			}

			else // tie 
            {
				diceRolled.Invoke(0, "Nope");

			}

			rivalDiceDone = false;
			playerDiceDone = false;

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
