using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class IronmanController : MonoBehaviour {

	//PRIVATE VARIABLES
	private Transform _transform;
	private Transform _playerController;
	private Vector2 _currentPosition;
	private Transform _enemyBulletTransform;

	//PUBLIC VARIABLES
	public GameObject player;
	public GameObject enemyBullet;
	public float _xMin;
	public float _xMax;
	public int switchDirection;
	public float speed;


	// Use this for initialization
	void Start () {

		this._transform = this.gameObject.GetComponent<Transform> ();
		this._playerController = this.player.GetComponent<Transform> ();
		//this._enemyBulletTransform = this.enemyBullet.gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		this._currentPosition = this._transform.position;

		if(this._currentPosition.x >= this._xMax){
			this.switchDirection = 0;
		}

		if (this._currentPosition.x <= this._xMin) {
			this.switchDirection = 1;
		}

		if (this.switchDirection == 0) {
			this._currentPosition -= new Vector2 (this.speed, 0);
			this._transform.position = this._currentPosition;
		}
		if (this.switchDirection == 1) {
			this._currentPosition += new Vector2 (this.speed, 0);
			this._transform.position = this._currentPosition;
		}


		if (this._playerController.position.x == (this._currentPosition.x - (this._currentPosition.x+100))) {
			//this.enemyBullet.gameObject.transform.position = new Vector2 (this._transform.position.x, this._transform.position.y);
			//Instantiate (this.enemyBullet.gameObject);

			//Instantiate (enemyBullet, new Vector3(transform.position.x - 30, transform.position.y, transform.position.z), Quaternion.identity);
			//Debug.Log (newBullet.transform.position.x);
			//newBullet.transform.position = new Vector2 (this._transform.position.x, this._transform.position.y);

			//Instantiate (this.enemyBullet);
			StartCoroutine(this.EnemyBulletWaves());
		}

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag ("playerBullets")) {
			Destroy(this.gameObject);
			Destroy (other.gameObject);
		}

	}

	IEnumerator EnemyBulletWaves(){
		//yield return new WaitForSeconds (5);
		float b = this._currentPosition.x - (this._currentPosition.x+100);
		while (this._playerController.position.x <= this._currentPosition.x && this._playerController.position.x >= b ) {
			for (int i = 0; i < 2; i++) {
				//this._enemyBulletTransform.position = new Vector3 (this._transform.position.x - 30, this._transform.position.y, this._transform.position.z);
				Instantiate (this.enemyBullet.gameObject, new Vector3 (this._transform.position.x - 30, this._transform.position.y, this._transform.position.z), Quaternion.identity);
				yield return new WaitForSeconds (1);
			}
			yield return new WaitForSeconds (2);
		}
	}

}
