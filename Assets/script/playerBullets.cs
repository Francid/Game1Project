using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerBullets : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform,_playerBulletTransform;
	private Vector2 _currentPosition;
	private float _initialPositionX;
	private WarCryGameController _WarCryGameController;
	//private float _horizontalDrift;


	//public bulletFiring enemy;
	public float speedRate;
	//public GameObject _player;



	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform>();
		this._initialPositionX = this._transform.position.x;
		this._WarCryGameController = GameObject.Find ("WarCryGameContoller").GetComponent<WarCryGameController> ();
		// Reset the bullets` Sprite to the Top
		//this.Reset ();
	}

	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		this._currentPosition += new Vector2 (speedRate, 0.0f);
		this._transform.position = this._currentPosition;

		if (SceneManager.GetActiveScene ().name != "Level2") {
			this._CheckBoundary ();
		}
		if (SceneManager.GetActiveScene ().name == "Level2") {
			this._bulletDistance ();
		}
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag ("MiniEnemy")) 
		{
			Destroy (this.gameObject);
			//Destroy (other.gameObject);
			this._WarCryGameController.ScoreValue += 20;
		}

		if (other.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (this.gameObject);
			Destroy (other.gameObject);
			this._WarCryGameController.ScoreValue += 10;
		}

		if (other.gameObject.CompareTag ("EnemyBoss")) {
			Destroy (this.gameObject);
			this._WarCryGameController.ScoreValue += 150;
		}
	}


	//PRIVATE METHODS
	private void _CheckBoundary(){

		if (this._currentPosition.x >= 335) {
			Destroy (this.gameObject);
		}
	}

	private void _bulletDistance(){
		if (this._currentPosition.x >= (this._initialPositionX + 335)) {
			Destroy (this.gameObject);
		}
	} 
}
