using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour{
	//private instance varialble
	private int _scoreValue;
	private int _livesValue;
	private int missiles = 3;

	private string str="Game Over" ;
	//private string str="Sorry You loose !" ;

	//public instance variable
	public Missile missileObj;
	//public Text score;
	//public Text lives;
	public Text winnerLoser;
	public Text highScore;
	public GameObject player;
	public GameObject airEnemy;
	public GameObject groundEnemy;
	public GameObject missileEnemy;
	public Button RESTART;

	//public access methods
	public int ScoreValue{get { return _scoreValue;} set{ this._scoreValue = value;}}
	public int LivesValue{get {return _livesValue; } set {this._livesValue = value; }}


	// Use this for initialization
	void Start () {
		this._initialize ();
	

	}
	
	// Update is called once per frame
	void Update () {
		//this.score.text = "Score: " + this._scoreValue;
		//this.lives.text = "Lives: " + this._livesValue;
		//if (this.groundEnemy == null ) 
		//	if(this.airEnemy == null)
//		if (this.groundEnemy == null)
//		if (this.airEnemy == null)
//		if (this.missileEnemy == null) {
//			this.winnerLoser.text = " You Win !";
//			this.highScore.text = "High Score: " + this._scoreValue;
//			SceneManager.LoadScene("scene/GameOver");
//			//Application.loadedLevel("GameOver");
//
//
//		}
//		
			//this.method1 ();

//		if (this.player == null) {
//
//			this.winnerLoser.text =str;
//			this.highScore.text = "High Score: " + this._scoreValue;
//			Destroy (this.airEnemy.gameObject);
//			Destroy (this.groundEnemy.gameObject);
//			Destroy (this.missileEnemy.gameObject);
//			this.RESTART.enabled = true;
//		}
	}

	private void _initialize(){
		//this.ScoreValue = 0;
		//this.LivesValue = 3;
		//this.RESTART.enabled = false;
		//Destroy (missileObj.gameObject);
		/*for (int missileCount=0;missileCount<missiles;missileCount++) {
			Instantiate (missileObj.gameObject);	*/	
		
		}


	public void restartButtonClick(){
	//	Application.loadLevel ("Main");
	
	}


}