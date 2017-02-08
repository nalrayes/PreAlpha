using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScripy : MonoBehaviour {

	public GameObject door;
	public Color32 oldColor;
	// Use this for initialization
	void Start () {
		oldColor = this.GetComponent<SpriteRenderer> ().color;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (door.activeSelf) {
			door.SetActive (false);	
			oldColor = this.GetComponent<SpriteRenderer> ().color;
			this.GetComponent<SpriteRenderer> ().color = new Color32 (67, 161, 99, 255);	
		} else {
			this.GetComponent<SpriteRenderer> ().color = oldColor;
			door.SetActive (true);
		}
	}
}
