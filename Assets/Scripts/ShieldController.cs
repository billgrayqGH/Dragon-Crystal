/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Shield Spawn
 */ 
using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {

	//shield health
	int shieldHP = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//detect collision on enemy and enemy bullet
	void OnTriggerEnter2D (Collider2D col){

		//shield is damaged when colliding with dragon and flames
		if ((col.tag == "Dragon1") || (col.tag == "DragonFire") || (col.tag == "Dragon2")|| (col.tag == "Dragon3") || (col.tag == "BossFire")|| (col.tag == "DragonBoss") ) {

			shieldHP--;

			//if player is dead, player game object will be hidden
			if (shieldHP <= 0) {
				
				//hide shield game object
				gameObject.SetActive (false);

			}
		}
	}
}
