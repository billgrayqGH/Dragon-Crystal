/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 24, 2016
 * Description: Handles Mini Enemy Dragon Movements
 */ 
using UnityEngine;
using System.Collections;

public class Enemy1Controller : MonoBehaviour {

	//reference to score text UI
	GameObject scoreUI;


	public GameObject explosiondrag; 
	float speed;


	// Use this for initialization
	void Start () {
		//enemy speed
		speed = 8f;
		//get the score UI
		scoreUI = GameObject.FindGameObjectWithTag("ScoreTag");

	}
	
	// Movement of Mini Dragons
	void Update () {
	
		Vector2 position = transform.position;

		position = new Vector2 (position.x - speed * Time.deltaTime, position.y);

		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if (transform.position.x < min.x) 
		{
			Destroy (gameObject);
		}
	}

	//detect collision on player and player bullet
	void OnTriggerEnter2D (Collider2D col){

		if ((col.tag == "MechaPlayer") || (col.tag == "PlayerBullet")|| (col.tag == "Shield")) {
			//play dragon cry audio
			GetComponent<AudioSource>().Play();

			//implement explosion
			explodedrag();

			//add 100 pts for each dragon killed
			scoreUI.GetComponent<GameScore>().Score += 100;

			//destroy dragon
			Destroy (gameObject);
		}

	}

	//function to create explosion
	void explodedrag()
	{
		GameObject explosion2 = (GameObject)Instantiate (explosiondrag);

		explosion2.transform.position = transform.position;

	}

}
