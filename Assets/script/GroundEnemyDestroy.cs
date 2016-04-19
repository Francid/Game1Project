using UnityEngine;
using System.Collections;

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
		//if(other.tag == "playerBullet"&& this.lives<0){
		if(other.tag == "playerBullet"){
			Instantiate (blast, other.transform.position, other.transform.rotation);
			this.lives -=1;
			//Destroy (other.gameObject);
			//Destroy (this.gameObject);
			//this.explosion.Play();
		}
		//this.lives -= 1;

	}
}
