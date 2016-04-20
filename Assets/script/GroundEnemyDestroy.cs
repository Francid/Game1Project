using UnityEngine;
using System.Collections;

/*
 * Author: Francis, Avenet, 
 * Last Modified by: Francis
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class GroundEnemyDestroy : MonoBehaviour {
	public GameObject blast;
	//private AudioSource[] audioSources;
	private AudioSource explosion;
	private int lives;

	// Use this for initialization
	void Start () {
		//this.explosion = gameObject.GetComponents<AudioSource> ();
		this.explosion = this.gameObject.GetComponent<AudioSource> ();
		this.lives = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.lives <= 0) {
			Destroy (this.gameObject);
		}
	
	}
	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.CompareTag("playerBullets")){
			Instantiate (blast, other.transform.position, other.transform.rotation);
			this.lives -=1;
		}
	}
}
