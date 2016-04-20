using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class BossEnemyController : MonoBehaviour {
	
	//PUBLIC VARIABLE
	public float speed;
	public GameObject enemyBullet;

	//PRIVATE VARIABLE
	private Transform _transform;
	private Transform _enemyBulletTransform;
	private Vector2 _currentPosition;
	private int _bulletPositionY;
	private bool _moveUp;
	private Level3Controller _level3Controller;

	// Use this for initialization
	void Start () {

		this._transform = gameObject.GetComponent<Transform> ();
		this._enemyBulletTransform = this.enemyBullet.gameObject.GetComponent<Transform> ();
		this._level3Controller = GameObject.Find ("Level3Controller").GetComponent<Level3Controller> ();
		this._bulletPositionY = 28;
		this._moveUp = true;
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
		this._currentPosition = this._transform.position;

		if (this._currentPosition.x == 205) {
			//Call the bullet coroutine
			StartCoroutine(EnemyBulletWaves());
		}

		if (this._currentPosition.x > 200) {
			this._currentPosition -= new Vector2 (this.speed, 0f);
			this._transform.position = this._currentPosition;
		}

		if (this._currentPosition.x == 200) {
			// Move on Y axis
			//this._currentPosition -= new Vector2 (0.0f, 2.0f);
			if (this._moveUp) {
				this._currentPosition += new Vector2 (0.0f, 2f);
				this._transform.position = this._currentPosition;
			} else {
				this._currentPosition -= new Vector2 (0.0f, 2f);
				this._transform.position = this._currentPosition;
			}
			this._CheckVerticalBoundary ();

		}

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag ("playerBullets")) {
			this._level3Controller.BossLifeLine--;
		}
	}

	IEnumerator EnemyBulletWaves(){
		//yield return new WaitForSeconds (5);
		while (true) {
			for (int i = 0; i < 2; i++) {
				this._enemyBulletTransform.position = new Vector2 (this._transform.position.x, this._transform.position.y + this._bulletPositionY);
				Instantiate (this.enemyBullet);
				this._bulletPositionY -= 56;
			}
			this._bulletPositionY = 28;
			yield return new WaitForSeconds (1);
		}
	}

	//PIVATE METHODS
	private void _Reset(){
		this._transform.position = new Vector2 (440f, 0f);
	}

	private void _CheckVerticalBoundary(){

		if (this._currentPosition.y >= 172) {
			this._moveUp = false;
		}
		if (this._currentPosition.y <= -172) {
			this._moveUp = true;
		}
	}
		
}
