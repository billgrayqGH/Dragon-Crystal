/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 25, 2016
 * Description: Handles Enemy Dragon Spawns
 */ 
using UnityEngine;
using System.Collections;

public class dragonSpawnerControl : MonoBehaviour {

	//dragon game objects
	public GameObject dragon1;
	public GameObject dragon2;
	public GameObject dragon3;
	public GameObject dragonBoss;

	//score game object
	public GameObject pScore;

	//player score
	int myScore;

	//max spawn in sec
	float maxSpawnRateInSec = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//spawn enemies
	void SpawnEnemy(){

		//bottom-left and top-right of the screen or camera bounds
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		myScore = pScore.GetComponent<GameScore>().Score;

		if (myScore <= 1500) {
			GameObject drag1 = (GameObject)Instantiate (dragon1);
			drag1.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			EnemyNextSpawn ();
		}
		else if (myScore > 1500 && myScore <= 3000) {
			StopSpawn ();
			GameObject drag2 = (GameObject)Instantiate (dragon2);
			drag2.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			EnemyNextSpawn ();
		}
		else if ((myScore > 3000) && (myScore <= 5000)) {
			StopSpawn ();
			GameObject drag3 = (GameObject)Instantiate (dragon3);
			drag3.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			EnemyNextSpawn ();
		}
		else if (myScore > 5000 ) {
			StopSpawn ();
			GameObject dragB = (GameObject)Instantiate (dragonBoss);
			dragB.transform.position = new Vector2 (12f, 1f);

		}

	}

	//next enemy spawn
	void EnemyNextSpawn(){

		float spawnSecs;

		if (maxSpawnRateInSec > 1.8f) {
			spawnSecs = Random.Range (1.8f, maxSpawnRateInSec);
		} 
		else {
			spawnSecs = 1.8f;
			Invoke ("SpawnEnemy", spawnSecs);
		}
	}

	// increase spawn rate
	void IncSpawnRate(){
	
		if (maxSpawnRateInSec > 1.8f) {
			maxSpawnRateInSec--;
		}

		if (maxSpawnRateInSec == 1.8f) {
			CancelInvoke ("IncSpawnRate");
		}
	}

	//make enemy spawn
	public void MakeEnemy()
	{
		Invoke ("SpawnEnemy", maxSpawnRateInSec);
		InvokeRepeating ("IncSpawnRate", 0f, 30f);
	}

	//stop enemy spawn
	public void StopSpawn()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncSpawnRate");
	}
}
