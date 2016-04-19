using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {

	private AudioSource _menuMusic;

	// Use this for initialization
	void Start () {
		this._menuMusic = this.gameObject.GetComponent<AudioSource> ();
		this._menuMusic.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Load Instruction Scene
	public void InstructionButtonClick(){
		SceneManager.LoadScene("Instructions");
	}

	//Load Level 1 Game Scene
	public void StartGameButtonClick(){
		SceneManager.LoadScene("main");
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

}
