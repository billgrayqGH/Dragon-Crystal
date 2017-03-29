/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Player Bullet Behaviour
 */ 
using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


	float speed; 

	void Start()
	{
		speed = 15f;
	}

	void Update ()
	{

		//bullet initial position
		Vector2 position = transform.position;

		//bullet travelling horizontally
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);

		transform.position = position;

		//bullet gets destroyed at end screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.x > max.x) 
		{
			Destroy (gameObject);
		}
	}

	//detect collision on enemy and enemy bullet
	void OnTriggerEnter2D (Collider2D col){

		if ((col.tag == "Dragon1") ||(col.tag == "Dragon2")||(col.tag == "Dragon3")||(col.tag == "DragonBoss")|| (col.tag == "DragonFire")) {

			Destroy (gameObject); //destroy player
		}

	}
}
