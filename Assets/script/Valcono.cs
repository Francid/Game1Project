using UnityEngine;
using System.Collections;

public class Valcono : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _verticalDrift;
	private float _verticalPosition;
	private bool _verticalLift;

	//public objects
	public Transform _player;

	// Use this for initialization
	void Start () {
		
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform>();
		//flag the vertical movement of volcano
		this._verticalLift=false;
		// Reset the bullets` Sprite to the Top
		this.Reset ();
	}

	// Update is called once per frame
	void Update () {
		if (this._verticalLift) {
			this._currentPosition = this._transform.position;
			this._currentPosition += new Vector2 (0f, this._verticalDrift);
			this._transform.position = this._currentPosition;
			if (this._currentPosition.y > this._verticalPosition) {
				this._verticalLift=false;
			}
		} else {
			this._currentPosition -= new Vector2 (0f, this._verticalDrift);
			this._transform.position = this._currentPosition;
			if (this._currentPosition.y < -430f) {
				this.Reset ();
			}
		
		
		}
	}

	public void Reset() {
		
		this._verticalPosition = Random.Range (0f,-430f);
		this._verticalDrift = 1f;
		this._transform.position = new Vector2 (this._transform.position.x, -418f);
		this._verticalLift=true;

	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			this._player.transform.position = new Vector2 (this._transform.position.x-2f, 0f);
		}
	
}
}