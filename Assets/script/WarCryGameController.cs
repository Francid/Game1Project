using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarCryGameController : MonoBehaviour
{

	//PRIVATE INSTANCE VARIABLE
	private int _scoreValue;
	private int _livesValue;
	private int _bkgResetCount;
	private AudioSource[] _audioSources;
	private AudioSource _gameMusic;
	private AudioSource _gameOverMusic;
	private int _scoreTracking;

	//PUBLIC INSTANCE VARIABLE
	public Text scoreLabel;
	public Text livesLabel;
	public Text highScoreLabel;
	public Text highScoreLabelText;
	public Text gameOverLabel;
	public Text levelLabel;

	public GameObject canvas;
	public GameObject scorePanel;
	public GameObject gameOverPanel;
	public GameObject menuPanel;

	//public access methods
	public int ScoreValue { 
		get {
			return _scoreValue; 
		} 
		set { 
			this._scoreValue = value;
			this.scoreLabel.text = "Score: " + this._scoreValue;
		} 
	}

	public int LivesValue { 
		get { 
			return _livesValue; 
		} 
		set { 
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._EndGame ();
			} else {
				this.livesLabel.text = "Lives: " + this._livesValue;
			}
		} 
	}

	public int BkgRestCount{
		get{
			return this._bkgResetCount;
		}
		set{
			this._bkgResetCount = value;
		}
	}

	// Use this for initialization
	void Start ()
	{
		this._initialize ();
		this.menuPanel.gameObject.SetActive(true);
		this.scorePanel.gameObject.SetActive (false);
		this.gameOverPanel.gameObject.SetActive (false);

		this._audioSources = this.gameObject.GetComponents<AudioSource> ();
		this._gameMusic = this._audioSources [0];
		this._gameOverMusic = this._audioSources [1];

		this._scoreTracking = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SceneManager.LoadScene ("main");
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SceneManager.LoadScene ("Level2");
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SceneManager.LoadScene ("Level3");
		}
	
	}

	//Load Instruction Scene
	public void InstructionButtonClick(){
		SceneManager.LoadScene("Instructions");
	}

	//Load Level 1 Game Scene
	public void StartGameButtonClick(){
		DontDestroyOnLoad (this.canvas);
		this.menuPanel.gameObject.SetActive(false);
		this.scorePanel.gameObject.SetActive(true);
		SceneManager.LoadScene("main");
		this._gameOverMusic.Stop ();
		this._gameMusic.Play ();
	}


	public void BackButtonClick()
	{
		SceneManager.LoadScene("Menu");
	}

	//Quit Game
	public void QuitButtonClick(){
		Application.Quit ();
	}

	//Load Settings Scene
	public void SettingsButtonClick(){
		SceneManager.LoadScene("Settings");
	}

	public void MenuButtonClick(){
		Destroy (this.canvas);
		Destroy (transform.gameObject);
		SceneManager.LoadScene ("Menu");
	}

	public void PlayAgainButtonClick(){
		this.menuPanel.gameObject.SetActive(false);
		this.scorePanel.gameObject.SetActive(true);
		this.gameOverPanel.SetActive (false);
		this._initialize ();
		this._gameMusic.Play ();
		this._gameOverMusic.Stop ();
		SceneManager.LoadScene ("main");
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}



	//PRIVATE METHODS
	private void _initialize ()
	{
		this.ScoreValue = 0;
		this.LivesValue = 10;
		this.gameOverLabel.text = "GAME OVER";
	}

	//END GAME
	public void _EndGame(){
		this.gameOverPanel.gameObject.SetActive(true);
		this.scorePanel.gameObject.SetActive (false);
		if (this._scoreTracking < this._scoreValue) {
			this._scoreTracking = this._scoreValue;
		}
		this.highScoreLabel.text = this._scoreTracking.ToString();
		this._gameMusic.Stop ();
		this._gameOverMusic.Play ();
		SceneManager.LoadScene ("GameOver");
	}
}
