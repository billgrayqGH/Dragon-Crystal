/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Boss Dragon Behaviour and Winning the Game
 */ 
using UnityEngine;
using System.Collections;

public class DragonBossController : MonoBehaviour {

	//game manager object
	public GameObject GM;

	//explosion game object
	public GameObject BossScore;

	//explosion game object
	public GameObject explosiondrag;

	//dragon boss life
	int bosslife = 30;
	 

	// Use this for initialization
	void Start () {

		//get score ui
		BossScore = GameObject.FindGameObjectWithTag("ScoreTag");
		GM = GameObject.FindGameObjectWithTag ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//detect collision on player and player bullet
	void OnTriggerEnter2D (Collider2D col){

		if ((col.tag == "MechaPlayer") || (col.tag == "PlayerBullet")|| (col.tag == "Shield")) {
			//play dragon cry audio
			GetComponent<AudioSource>().Play();

			//implement explosion
			explodedrag();

			bosslife--;

			if (bosslife == 0) {

 		      //add 10000 pts if boss is killed
				BossScore.GetComponent<GameScore> ().Score += 10000;

				//destroy dragon
				Destroy (gameObject);

				//Game Over Game Manager State
				GM.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.YouWin);
			}
		}

	}

	//function to create explosion
	void explodedrag()
	{
		GameObject explosion2 = (GameObject)Instantiate (explosiondrag);

		explosion2.transform.position = transform.position;

	}
}
