/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 25, 2016
 * Description: Handles Dragon Fire Breath/Bullets Movement
 */ 
using UnityEngine;
using System.Collections;

public class FlameSpit : MonoBehaviour {

	float speed;
	Vector2 _direction;
	bool firing;

	void Awake(){
	
		speed = 15f;
		firing = false;
	}

	// Use this for initialization
	void Start () {
	
	}

	public void SetDirection(Vector2 direction){
		_direction = direction.normalized;

		firing = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (firing) {
		
			//when dragon AI is ready to fire
			Vector2 position = transform.position;

			//bullet travelling on the player
			position += _direction * speed * Time.deltaTime;

			transform.position = position;

			//bullet destroyed at the end of the screen
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

			if((transform.position.x < min.x) || (transform.position.x > max.x) ||
				(transform.position.y < min.y) || (transform.position.y > max.y)){

				Destroy (gameObject);


				}
	
		}
	}

	//detect collision on player and player bullet
	void OnTriggerEnter2D (Collider2D col){

		if ((col.tag == "MechaPlayer") || (col.tag == "PlayerBullet")|| (col.tag == "Shield") ) {

			Destroy (gameObject); //destroy player
		}

	}


}