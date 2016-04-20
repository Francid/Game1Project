﻿using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class Groundfire : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _verticalSpeed;
	private float _horizontalDrift;
	//private bulletFiring enemy;
	public GameObject tank;


	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform>();
		// Reset the bullets` Sprite to the Top
		this.Reset ();
	}

	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		this._currentPosition -= new Vector2(this._horizontalDrift, this._verticalSpeed);
		this._transform.position = this._currentPosition;

		if (this._currentPosition.y >=100 && this._currentPosition.x <=-400) {
			this.Reset ();
		}
	}

	public void Reset() {
		this._verticalSpeed=-2f;
		this._horizontalDrift = 7f;

		this._transform.position = this.tank.transform.position;
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {
			this.Reset ();
		}
	}
}
