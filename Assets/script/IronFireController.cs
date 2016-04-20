using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class IronFireController : MonoBehaviour {

	//PUBLIC VARIABLES
	public float speed;

	//PRIVATE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _initialPositionX;

	// Use this for initialization
	void Start () {

		this._transform = gameObject.GetComponent<Transform> ();
		this._initialPositionX = this._transform.position.x;

		//this.Reset ();
		StartCoroutine("Fly");
		StartCoroutine ("DeathTimer");
	}

	// Update is called once per frame
	void Update () {

		//this._currentPosition = this._transform.position;
		//this._currentPosition -= new Vector2 (this.speed, 0.0f);
		//this._transform.position = this._currentPosition;

		//this._bulletDistance ();
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (other.gameObject.CompareTag ("playerBullets")) {
			Destroy(this.gameObject);
			Destroy (other.gameObject);
		}

	}
	IEnumerator DeathTimer(){
		yield return new WaitForSeconds (2);
		Destroy (this.gameObject);
	}

	IEnumerator Fly(){
		while (enabled) {
			transform.Translate (new Vector2 (-250 * Time.deltaTime, 0));
			yield return null;
		}
	}

//	private void _bulletDistance(){
//		Debug.Log ("bullet Position: " + this._currentPosition.x + "destroy position: " + (this._initialPositionX - 364));
//		if (this._currentPosition.x <= (this._initialPositionX - 364)) {
//			Debug.Log ("Destroyed");
//			Destroy (this.gameObject);
//		}
//	} 

}
