using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class BackgroundMover : MonoBehaviour {

	//PUBLIC VARIABLES
	public float speed;
	public float resetPosition;

	//PRIVATE VBARIABLES
	private Transform _transform;
	private Vector2 _backgroundPosition;
	private AudioSource[] audioSources;
	private AudioSource music;
	//private int _bkgResetCount;
	private WarCryGameController _warCryGameController;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		//initialize the audio sources array
		//this.audioSources = gameObject.GetComponents<AudioSource> ();
		//this.music = this.audioSources [0];
		//this.music.Play ();
		this._warCryGameController = GameObject.Find ("WarCryGameContoller").GetComponent<WarCryGameController> ();
		this._warCryGameController.BkgRestCount = 0;
		this.Reset ();
		//this._bkgResetCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this._backgroundPosition = this._transform.position;
		this._backgroundPosition -= new Vector2 (this.speed, 0.0f);
		this._transform.position = this._backgroundPosition;

		if(this._backgroundPosition.x <= -resetPosition){
			this.Reset();
		}

		// The Background reset count
		if(this._warCryGameController.BkgRestCount > 30){
			//LOAD NEXT SCENE
			this._LoadNextScene();
		}
	}

	public void Reset(){
		this._transform.position = new Vector2 (resetPosition, 0.0f);
		this._warCryGameController.BkgRestCount++;
	}

	//PRIVATE METHODS BELOW

	private void _LoadNextScene(){
		SceneManager.LoadScene ("GameOver");
	}
}
