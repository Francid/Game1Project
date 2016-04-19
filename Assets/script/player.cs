using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float speed ;
	public float fireRate;
	public GameObject playerBullet;
	public int xmin, xmax, ymin, umax;

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Transform _playerBulletTransform;
	private Vector2 _currentPosition;
	private float inputx; //to move up-down form arrow keys 
	private float inputy;//to move forward-backword form arrow keys 
	private float nextFire;

	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform> ();
		this._playerBulletTransform = this.playerBullet.gameObject.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				this.nextFire = Time.time + fireRate;
				this._playerBulletTransform.position = new Vector2 (this._transform.position.x + 80, this._transform.position.y - 10);
				Instantiate (this.playerBullet);
			}

		this._currentPosition = this._transform.position;
		this.inputx = Input.GetAxis ("Vertical");
		this.inputy = Input.GetAxis ("Horizontal");


		if (this.inputx > 0)
			this._currentPosition += new Vector2 (0,this.speed);
		if (this.inputx < 0) 
			this._currentPosition -= new Vector2 (0, this.speed);
		if (this.inputy > 0)
			this._currentPosition += new Vector2 (this.speed,0);
		if (this.inputy < 0) 
			this._currentPosition -= new Vector2 (this.speed,0);	
		
		this.checkPosiiton ();
		this._transform.position = this._currentPosition;

		if (this._currentPosition.x >= 7155) {
			this._NextScene ();
		}

	}

	void Awake(){
		//DontDestroyOnLoad (transform.gameObject);
	}

	public void checkPosiiton() {
		if (this._currentPosition.y < this.ymin) {
			this._currentPosition.y = this.ymin;
		}
		if (this._currentPosition.y > this.umax) {
			this._currentPosition.y = this.umax;
		}
		
		if (this._currentPosition.x > this.xmax) {
			this._currentPosition.x = this.xmax;
		}
		if (this._currentPosition.x < this.xmin) {
			this._currentPosition.x = this.xmin;
		}
		
	}

	private void _NextScene(){
		SceneManager.LoadScene ("Level3");
	}

//<<<<<<< HEAD
//=======
//
//	private void _CheckBoundary(){
//		if (this.playerBullet.transform.position.x > this.transform.position.x + 500f) {
//
//			//this._transform.position = this._player.transform.position;
//
//			//this._currentPosition = this._transform.position;
//			//this._currentPosition=new Vector2 (this._player.transform.position.x, 0f);
//
//			//	this._currentPosition =	this._transform.position;
//			//	this.check = false;
//			Destroy (this.playerBullet.gameObject);
//		}
//	}
//
//>>>>>>> upstream/master
}
