using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScripy : MonoBehaviour {

	public GameObject door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		door.SetActive (false);	
		
		this.GetComponent<SpriteRenderer> ().color = new Color32 (67, 161, 99, 255);	
	}

}
