/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 25, 2016
 * Description: Handles Dragon Breath/Bullet Direction
 */ 
using UnityEngine;
using System.Collections;

public class fireBreathControl : MonoBehaviour {

	public GameObject fireSpit;
	 
	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("Flame", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Flame(){
		//fire at the players direction
		GameObject target = GameObject.Find ("character");

		if (target != null) {
			GameObject flame1 = (GameObject)Instantiate (fireSpit);

			flame1.transform.position = transform.position;

			//bullet movement towards the player
			Vector2 direction = target.transform.position - flame1.transform.position;

			flame1.GetComponent<FlameSpit>().SetDirection (direction);
		}
	}
}
