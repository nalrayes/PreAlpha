using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
	public bool posessed = false;
	int timer = 0;

	const int MAX_TIME = 90;

	GameObject jinn;

	// Use this for initialization
	void Start () {
		jinn = GameObject.Find ("Circle");
	}
	
	// Update is called once per frame
	void Update () {
		if (posessed) {
			timer++;
			if (timer > MAX_TIME || Input.GetKey (KeyCode.Space)) {
				timer = 0;
//				jinn.SetActive (true);
				jinn.GetComponent<JinnScript> ().posessing = false;
				posessed = false;
				GetComponent<Animator> ().SetBool ("posessed", false);
			} else if (Input.GetKey (KeyCode.Q)) {
				// do fire thing
				GetComponent<Animator> ().SetTrigger ("boom");
			} 
		}
	}

	void OnTriggerStay2D(Collider2D thing) {
		if (thing.gameObject.CompareTag ("jinn")) {
			jinn.SetActive (false);
			jinn.GetComponent<JinnScript> ().posessing = true;
			posessed = true;
			GetComponent<Animator> ().SetBool ("posessed", true);
		} else if (thing.gameObject.CompareTag ("summoner")) {
			// do dmg
			thing.GetComponent<PropertyScript>().changeHealth(-1);
		} else if (thing.gameObject.CompareTag ("enemy")) {
			//kill
			thing.GetComponent<EnemyScript>().hits  = 2;
		}
	}
}
