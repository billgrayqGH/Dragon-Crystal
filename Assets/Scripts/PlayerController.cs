/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Player Movement
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//reference to game manager, score and crystal count
	public GameObject GameManager1; 
	public GameObject RedScore;
	//public GameObject CC;

	//player gun, bullets, shields and explosion game objects
	public GameObject bullet;
	public GameObject gun;
	public GameObject shield;
	public GameObject explosion; 

	//reference to life,gem,score ui text
	public Text TextLifeUI;
	public Text TextGemUI;


	//max player life
	const int maxLife = 10;
	//player current life
	int currLife;
	//collected gems
	int gem;
	//score to be added
	int aScore;


	//movement speed
	public float speed;


	public void Init(){

		//restart position
		transform.position = new Vector2 (-12f, 2);

		//reset life to max life
	    currLife = maxLife;

		//update text UI for life remaining
		TextLifeUI.text = currLife.ToString ();

		//setting player game object to active
		gameObject.SetActive(true);
	
	}

	void Start () {

		//get the score UI
		RedScore = GameObject.FindGameObjectWithTag("ScoreTag");
		//get the crystal UI
		//CC = GameObject.FindGameObjectWithTag("CrystalTag");
	}

	void Update()
	{
		//Player movement input
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		//direction of input
		Vector2 direction = new Vector2 (inputX, inputY).normalized;

		//function to move player
		Move (direction);

		//firing bullets
		if (Input.GetKeyDown ("space")) 
		{
			//play bullet sound
			GetComponent<AudioSource>().Play();
			GameObject bullet1 = (GameObject)Instantiate (bullet);
			bullet1.transform.position = gun.transform.position; 
		}	

	}

	void Move(Vector2 direction)
	{
		//bottom-left and top-right camera bounds
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//half of my mecha's dimensions
		max.x = max.x - 0.8904625f;
		min.x = min.x + 0.8904625f;

		max.y = max.y - 1.151757f;
		min.y = min.y + 1.151757f;

		//my mecha movement
		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		//Check bounds
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		//move player to camera bounds
		transform.position = pos;
	}

	//detect collision on enemy and enemy bullet
	void OnTriggerEnter2D (Collider2D col){

		//mecha damaged when colliding with dragon and flames
		if ((col.tag == "Dragon1") || (col.tag == "DragonFire") || (col.tag == "Dragon2")|| (col.tag == "Dragon3") || (col.tag == "BossFire")|| (col.tag == "DragonBoss") ) {

			explode ();// player explosion animation
			currLife--;//decrease remaining life
			TextLifeUI.text = currLife.ToString();//Update remaining life

			//if player is dead, player game object will be hidden
			if(currLife == 0){

				//Game Over Game Manager State
				GameManager1.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
				//hide player game object
				gameObject.SetActive(false);

			}
		}

		//mecha gains life from blue crystal
		if (col.tag == "BlueCrystal") {
			currLife++;//Increase remaining life
			TextLifeUI.text = currLife.ToString();//Update remaining life
		}

		if (col.tag == "GreenCrystal") {
			gem++;//Increase gems collected
			TextGemUI.text = gem.ToString();//Update remaining life

			//int gemCount = CC.GetComponent<CrystalCount> ().Crystal;

				shield.SetActive (true);
		

		}

		if (col.tag == "RedCrystal") {
			//add 200 pts for each red crystal
			RedScore.GetComponent<GameScore>().Score += 200;
		}

	}

	//function to create explosion
	void explode()
	{
		GameObject explosion1 = (GameObject)Instantiate (explosion);

		explosion1.transform.position = transform.position;

	}

}
