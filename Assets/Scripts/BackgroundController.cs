/*
 * Bill Gray Quitalig
 * 100 950 279
 * Last Coded: Oct 24, 2016
 * Description: Handles Background Movement
 */ 
using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	//slow speed for moving background
	float speed = 0.05f;

	private Transform _transform = null;
	private Vector2 _currentPosition ;

	//Constants
	private const float startPos = 38f;
	private const float resetPos = -38f;

	// Use this for initialization
	void Start () {

		_transform = gameObject.transform;
		_currentPosition = _transform.position;

		//Reset the position
		Reset ();
	}

	// Update method in moving the background
	void Update () {

		// scrolling backgriund
		_currentPosition = _transform.position;
		_currentPosition -= new Vector2(speed, 0);
		_transform.position = _currentPosition;

		if (gameObject.transform.position.x < resetPos)
			Reset ();
	}

	//Reset backgorund
	public void Reset(){

	
		_currentPosition = new Vector2(startPos, 0);
		_transform.position = _currentPosition;


	}


}
