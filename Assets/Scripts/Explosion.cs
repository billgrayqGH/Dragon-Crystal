/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 25, 2016
 * Description: Handles Explosion Animation
 */ 
using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	void DestroyGameObject(){
		//destroy explosion animation
		Destroy(gameObject);
	}
}
