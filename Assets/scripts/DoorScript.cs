using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	bool posessed;
	int timer;
	GameObject jinn;
	Vector3 originalPosition;

	Color32 originalColor;

	// Use this for initialization
	void Start () {
		timer = 0;
		jinn = GameObject.FindGameObjectWithTag ("jinn");
		originalColor = gameObject.GetComponent<SpriteRenderer> ().color;
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (posessed) {
			timer++;
			if (Input.GetKey (KeyCode.Q)) {
				gameObject.transform.position += Vector3.up * Time.deltaTime;
			}
			if (timer > 150) {
				timer = 0;
				posessed = false;
				jinn.GetComponent<JinnScript> ().posessing = false;
				gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
			}
		} else {
			if (transform.position != originalPosition) {
				transform.position = Vector3.MoveTowards (transform.position, originalPosition, Time.deltaTime);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag("jinn")) {
			info.gameObject.SetActive (false);
			info.gameObject.GetComponent<JinnScript> ().posessing = true;
			posessed = true;

			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 30, 255);
		}
	}
}
