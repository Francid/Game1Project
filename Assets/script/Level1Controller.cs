using UnityEngine;
using System.Collections;

public class Level1Controller : MonoBehaviour {

	/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

	//PRIVATE VARIABLES
	public GameObject miniEnemy;
	public GameObject coins;

	//PUBLIC VARIABLES


	// Use this for initialization
	void Start () {
		this._InitializeLevelObjects ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void _InitializeLevelObjects(){
		Instantiate (this.miniEnemy);

		for (int i = 0; i < 3; i++) {
			Instantiate (this.coins);
		}
	}
}
