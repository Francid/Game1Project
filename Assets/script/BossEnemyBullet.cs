using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class BossEnemyBullet : MonoBehaviour {

	//PUBLIC VARIABLES
	public float speed;

	//PRIVATE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {

		this._transform = gameObject.GetComponent<Transform> ();
		//this.Reset ();
	}
	
	// Update is called once per frame
	void Update () {

		this._currentPosition = this._transform.position;
		this._currentPosition -= new Vector2 (this.speed, 0.0f);
		this._transform.position = this._currentPosition;

		if (this._currentPosition.x <= -327) {
			Destroy (this.gameObject);
		}

	}
		
	void OnTriggerEnter2D (Collider2D other){
		
		if (other.gameObject.CompareTag ("playerBullets")) {
			Destroy (this.gameObject);
		}
	}

}
