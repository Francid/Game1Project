using UnityEngine;
using System.Collections;
/*
 * Author: Francis, Avenet, 
 * Last Modified by: Avenet
 * Last Modified: 20/04/2016
 * File description: Moves the backgrounds
*/

public class CameraFollow : MonoBehaviour {
	public float xMax;
	public float xMin;

	public float yMax;
	public float yMin;
	public GameObject playerObj;

	private Transform target; 
	// Use this for initialization
	void Start () {
		target = playerObj.GetComponent<Transform> ();
	

	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		if (this.playerObj != null)
			transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax), transform.position.z);
		else {
			transform.position = new Vector3 (0f, 0f, transform.position.z);
			return;
		}
	}
}
