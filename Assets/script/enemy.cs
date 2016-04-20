using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class enemy : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float speed ;

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform> ();

		// Reset the Ocean Sprite to the Top
		//this.Reset ();
	}

	// Update is called once per frame
	void Update () {

		this._currentPosition = this._transform.position;

		if (this._currentPosition.x > 80) {
			//this.Reset ();
			this._currentPosition = this._transform.position;
			this._currentPosition -= new Vector2(this.speed,0);
			this._transform.position = this._currentPosition;
		}

	}

	public void Reset() {
		this._transform.position = new Vector2 (100,this._currentPosition.y);
	}
}
