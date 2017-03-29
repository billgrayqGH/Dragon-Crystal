/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Manages the Game States
 */ 
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Reference to game objects to be hidden
	public GameObject startButton;
	public GameObject logo;
	public GameObject dragSpawner;
	public GameObject crystSpawner;
	public GameObject gameOver1;
	public GameObject youWin1;



	//Reference to game objects to be shown/reset
	public GameObject score;
	public GameObject gem;
	public GameObject life;
	public GameObject scoretext;
	public GameObject gemtext;
	public GameObject lifetext;
	public GameObject playermecha;
	public GameObject myShield;



	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
		YouWin,
	}
	GameManagerState GMState;
	 
	// Use this for initialization
	void Start () {

		GMState = GameManagerState.Opening;

	
	}
	
	//EXTERNAL CODE (ONLY FOR THE 'CASE' ON THE METHOD) : Update Game Manager State
	/* Author of the Code Source: Carlos_B
 	* Posted Date: March 3, 2015
 	* Code Source:http://www.pixelelement.com/blog/unity-2d-space-shooter-tutorial-part-7/ */
	void UpdateGameManagerState () {

		switch (GMState) {

		case GameManagerState.Opening:
			//Hide game over
			gameOver1.SetActive(false);

			//Hide you win
			youWin1.SetActive(false);

			//Set logo and play button visible
			logo.SetActive(true);
			startButton.SetActive(true);

			//hide game UI
			score.SetActive (false);
			scoretext.SetActive (false);
			gem.SetActive (false);
			gemtext.SetActive (false);
			life.SetActive (false);
			lifetext.SetActive (false);


			break;

		case GameManagerState.Gameplay:
			//reset score
			scoretext.GetComponent<GameScore> ().Score = 0;

			//reset crystal numbers
			gemtext.GetComponent<CrystalCount>().Crystal = 0;
			
			//hide start button and logo
			startButton.SetActive (false);
			logo.SetActive (false);

			//hide shield
			myShield.SetActive(false);

			//display player
			playermecha.GetComponent<PlayerController> ().Init ();

			//display game UI
			score.SetActive (true);
			scoretext.SetActive (true);
			gem.SetActive (true);
			gemtext.SetActive (true);
			life.SetActive (true);
			lifetext.SetActive (true);

			//make enemy spawn
			dragSpawner.GetComponent<dragonSpawnerControl> ().MakeEnemy ();

			//make crystal spawn
			crystSpawner.GetComponent<crystalSpawner> ().makeCrystals ();

			break;

		case GameManagerState.GameOver:

			//Stop enemy spawn
			dragSpawner.GetComponent<dragonSpawnerControl> ().StopSpawn ();

			//stop crystal spawn
			crystSpawner.GetComponent<crystalSpawner> ().StopSpawnCryst ();

			//hide game UI
			score.SetActive (false);
			scoretext.SetActive (false);
			gem.SetActive (false);
			gemtext.SetActive (false);
			life.SetActive (false);
			lifetext.SetActive (false);

			//Display Game Over
			Invoke ("DisplayGameOver", 2f);

			//Change game manager state to opening after 10 secs
			Invoke("GoToOpeningState",5f);


			break;

		case GameManagerState.YouWin:

			//Stop enemy spawn
			dragSpawner.GetComponent<dragonSpawnerControl> ().StopSpawn ();

			//stop crystal spawn
			crystSpawner.GetComponent<crystalSpawner> ().StopSpawnCryst ();

			//hide game UI
			score.SetActive (false);
			scoretext.SetActive (false);
			gem.SetActive (false);
			gemtext.SetActive (false);
			life.SetActive (false);
			lifetext.SetActive (false);
			playermecha.SetActive (false);

			//Display Game Over
			Invoke ("DisplayYouWin", 2f);

			//Change game manager state to opening after 10 secs
			Invoke("GoToOpeningState",5f);

			break;



		}
	}

	// set game manager state
	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;

		UpdateGameManagerState ();

	}

	// start the game function, it will be called when the user press 'start'
	public void StartGame(){
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	// change the game manager state to opening state
	public void GoToOpeningState(){
	
		SetGameManagerState (GameManagerState.Opening);
	
	}

	//Display Game Over
	public void DisplayGameOver()
	{
		
		gameOver1.SetActive(true);
	}
	//Display You Win
	public void DisplayYouWin()
	{
		youWin1.SetActive(true);
	}	
}
