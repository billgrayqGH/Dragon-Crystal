/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Crystal Movements
 */ 
using UnityEngine;
using System.Collections;

public class CrystalController : MonoBehaviour {


	float speed;

	// crystal initialization
	void Start () {
		//crystal speed
		speed = 3f;
	}
	
	// Movement of Crystals
	void Update () {

		//Falling movement of Crystals
		Vector2 position = transform.position;

		position = new Vector2 (position.x , position.y - speed * Time.deltaTime);

		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if (transform.position.y < min.y) 
		{
			Destroy (gameObject);
		}
	
	}

	//detect collision on player and player bullet
	void OnTriggerEnter2D (Collider2D col){

		if (col.tag == "MechaPlayer") {
			//play crystal power up sound
			GetComponent<AudioSource>().Play();

			//destroy crystal
			Destroy (gameObject);
		}

	}
}
