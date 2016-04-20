using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class EnemyMiniController : MonoBehaviour {

	//PUBLIC VARIABLES
	public float speed;
	public float xboundary;
	public float yboundary;

	//PRIVATE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {

		this._currentPosition = this._transform.position;
		this._currentPosition -= new Vector2 (this.speed, 0.0f);
		this._transform.position = this._currentPosition;

		if (this._currentPosition.x <= -xboundary) {
			this._Reset ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			this._Reset ();
		}

		if (other.gameObject.CompareTag ("playerBullets")) {
			this._Reset ();
		}
	}


	//PRIVATE METHODS
	private void _Reset(){

		this.transform.position = new Vector2 (xboundary, Random.Range (-yboundary, yboundary));
	}
}
