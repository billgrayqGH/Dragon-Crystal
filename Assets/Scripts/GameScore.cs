/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 26, 2016
 * Description: Handles Game Scores
 */ 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {

	//Game Object of Game Score
	public GameObject gScore;

	 int score;

	//Player Score Constructor
	public int Score
	{
		get{
			return this.score;
		}

		set{

			this.score = value;

			//display game score in the text game object
			Text txt = gScore.GetComponent<Text>();
			txt.text = "" + score;
		}

	}

	// Use this for initialization
	void Start () {
	



	}



}
