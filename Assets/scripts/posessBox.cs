using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posessBox : MonoBehaviour {
	GameObject jinn;
	int timer = 0;
	bool posessed = false;
	bool still = false;
	Color32 originalColor;
	float speed = 4f;

	// Use this for initialization
	void Start () {
		originalColor = gameObject.GetComponent<SpriteRenderer> ().color;
		jinn = GameObject.FindGameObjectWithTag ("jinn");
	}
	
	// Update is called once per frame
	void Update () {
		if (posessed) {
			timer++;
			if (!still) {
				if (Input.GetKey (KeyCode.RightArrow)) {
					transform.position += Vector3.right * speed * Time.deltaTime;
				}
				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.position += Vector3.left * speed * Time.deltaTime;
				}
				if (Input.GetKey (KeyCode.UpArrow)) {
					transform.position += Vector3.up * speed * Time.deltaTime;
				}
				if (Input.GetKey (KeyCode.DownArrow)) {
					transform.position += Vector3.down * speed * Time.deltaTime;
				}
			}
			if (Input.GetKey (KeyCode.Q)) {
				if (still) {
					gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 30, 255);
					still = false;
					gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				} else {
					gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 180, 255);
					still = true;
					gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				}
			}
			if (timer > 800 || Input.GetKey (KeyCode.Space)) {
				gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
				timer = 0;
				posessed = false;
				jinn.GetComponent<JinnScript> ().posessing = false;
				gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag ("jinn")) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 30, 255);	
			posessed = true;
			info.gameObject.SetActive (false);
			info.gameObject.GetComponent<JinnScript> ().posessing = true;
		}
	}
}
