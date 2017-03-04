using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScripy : MonoBehaviour {

	public GameObject door;
	public Color32 oldColor;
	Color32 originalColor;

	public bool posessed = false;

	float timer;
	int ftimer;
	GameObject jinn;

	// Use this for initialization
	void Start () {
		ftimer = 0;
		originalColor = this.GetComponent<SpriteRenderer> ().color;
		door = GameObject.Find ("Door");
	}
	
	// Update is called once per frame
	void Update () {
		if (posessed) {
			timer++;
			ftimer++;
			if (Input.GetKey (KeyCode.Q)) {
				if (door.activeSelf) {
					door.SetActive (false);	
					oldColor = this.GetComponent<SpriteRenderer> ().color;
					this.GetComponent<SpriteRenderer> ().color = new Color32 (67, 161, 99, 255);
				} else {
					this.GetComponent<SpriteRenderer> ().color = new Color32(180, 180, 30, 255); 
					if (ftimer > 3) {
						door.SetActive (true);
						ftimer = 0;
					}
				}
			}
			if (timer > 150 || Input.GetKey(KeyCode.Space)) {
				timer = 0;
				posessed = false;
				jinn.SetActive (true);
				Vector3 rightOf = new Vector3 (1.2f, 0f);
				jinn.transform.position = GameObject.FindGameObjectWithTag ("summoner").transform.position + rightOf;
				jinn.GetComponent<JinnScript> ().posessing = false;
				this.GetComponent<SpriteRenderer> ().color = originalColor;
			}
		}	
	}
		
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (collisionInfo.gameObject.CompareTag ("jinn")) {
			jinn = collisionInfo.gameObject;
			jinn.SetActive (false);
			timer = 0;
			jinn.GetComponent<JinnScript> ().posessing = true;
			posessed = true;
			this.GetComponent<SpriteRenderer>().color =  new Color32(180, 180, 30, 255);
		} else {
			if (door.activeSelf) {
				door.SetActive (false);	
				oldColor = this.GetComponent<SpriteRenderer> ().color;
				this.GetComponent<SpriteRenderer> ().color = new Color32 (67, 161, 99, 255);	
			} else {
				this.GetComponent<SpriteRenderer> ().color = originalColor;
				door.SetActive (true);
			}
		}
	}
}
