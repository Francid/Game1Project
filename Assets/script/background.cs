using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class background : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float speed ;

	//PRIVATE INSTANCE VARIABLES
	private AudioSource[] audioSources;
	private AudioSource music;
	private int _bkgResetCount;
	private Transform _transform;
	private Vector2 _currentPosition;
	private WarCryGameController _warCryGameController;

	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform> ();

		// Reset the Ocean Sprite to the Top
		this.Reset ();
		//initialize the audio sources array
		this.audioSources = gameObject.GetComponents<AudioSource> ();
		this._warCryGameController = GameObject.Find ("WarCryGameContoller").GetComponent<WarCryGameController> ();
		this._warCryGameController.levelLabel.text = "Level: 1";
		this.music = this.audioSources [0];
		this.music.Play ();
		//Initialize 
		this._bkgResetCount = 0;
	}

	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		this._currentPosition -= new Vector2(this.speed,0);
		this._transform.position = this._currentPosition;

		if (this._currentPosition.x <= -614) {
			this.Reset ();
		}

		// The Background reset count
		if(this._bkgResetCount >20){
			//LOAD NEXT SCENE
			this._LoadNextScene();
		}
	}

	public void Reset() {
		this._transform.position = new Vector2 (614f,0);
		this._bkgResetCount++;
	}


	//PRIVATE METHODS BELOW

	private void _LoadNextScene(){
		this._warCryGameController.levelLabel.text = "Level: 2";
		SceneManager.LoadScene ("Level3");
	}
}
