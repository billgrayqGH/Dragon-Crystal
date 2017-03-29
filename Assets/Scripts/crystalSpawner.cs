/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Crystal Spawning
 */ 
using UnityEngine;
using System.Collections;

public class crystalSpawner : MonoBehaviour {


	// game objects
	public GameObject redCrystal;
	public GameObject greenCrystal;
	public GameObject blueCrystal;

	float top = 7f;
	float left = -16f;
	float right = 16f;

	// Use this for initialization
	 public void makeCrystals () {

		InvokeRepeating ("createRed", 0f, 7f);
		InvokeRepeating ("createGreen", 3f,11f);
		InvokeRepeating ("createBlue", 5f, 18f);

	}

	//stop enemy spawn
	public void StopSpawnCryst()
	{
		CancelInvoke ("createRed");
		CancelInvoke ("createGreen");
		CancelInvoke ("createBlue");
	}

	//create red crystals
	void createRed () {
		GameObject red = (GameObject)Instantiate (redCrystal);
		red.transform.position = new Vector2 (Random.Range (left, right), top);
	}
	//create blue crystals
	void createBlue () {
		GameObject blue = (GameObject)Instantiate (blueCrystal);
		blue.transform.position = new Vector2 (Random.Range (left, right), top);
	}
	//create green crystals
	void createGreen () {
		GameObject green = (GameObject)Instantiate (greenCrystal);
		green.transform.position = new Vector2 (Random.Range (left, right), top);
	}
}
