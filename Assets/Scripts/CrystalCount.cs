/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 27, 2016
 * Description: Handles Crystal Count
 */ 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrystalCount : MonoBehaviour {


	//Game Object of Game Crystal
	public GameObject gCrystal;

    int crystal;

	//Player Score Constructor
	public int Crystal
	{
		get{
			return this.crystal;
		}

		set{

			this.crystal = value;

			//display game score in the text game object
			Text txt = gCrystal.GetComponent<Text>();
			txt.text = "" + crystal;
		}

	}
	// Use this for initialization
	void Start () {
	
	}
	

}
