using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class dragon : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _horizontalDrift;
	private float _verticalPosition;
	private Transform _enemyBulletTransform;

	//public objects
	public GameObject player;
	public GameObject enemyBullet;
	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform>();
		this._enemyBulletTransform = this.enemyBullet.gameObject.GetComponent<Transform> ();
		// Reset the bullets` Sprite to the Top
		this.Reset ();

		this._enemyBulletTransform.position = this._transform.position;
		Instantiate (this.enemyBullet);
	}

	// Update is called once per frame
	void Update () {
//		this._currentPosition = this._transform.position;
//		this._currentPosition.y = this._verticalPosition;
//		this._currentPosition -= new Vector2(this._horizontalDrift,0f);
//		this._transform.position = this._currentPosition;
//		if (this._currentPosition.x < this.player.transform.position.x-100f) {
//			this.Reset ();
//		}
//
		//StartCoroutine(EnemyBulletWaves());
	}

	public void Reset() {
		this._verticalPosition = Random.Range (-213f,157f);
		this._horizontalDrift = 2f;
		this._transform.position = new Vector2 (this.player.transform.position.x+600, 0);

	}

//	void OnTriggerEnter2D(Collider2D other){
//		if (other.tag == "upWall") {
//			this._transform.position = new Vector2 (0f,this._transform.position.y+40.534f);
//		
//		}
//		if (other.tag == "downWall") {
//			this._transform.position = new Vector2 (0f,this._transform.position.y-40.534f);
//		
//		}
//	}

//	IEnumerator EnemyBulletWaves(){
//		//yield return new WaitForSeconds (5);
//		while (true) {
//			for (int i = 0; i < 2; i++) {
//				this._enemyBulletTransform.position = this._transform.position;
//				Instantiate (this.enemyBullet);
//				//yield return new WaitForSeconds (2);
//			}
//			yield return new WaitForSeconds (4);
//		}
//	}

}
