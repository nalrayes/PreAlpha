using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	bool posessed;
	int timer;
	GameObject jinn;
	Vector3 originalPosition;

	Color32 originalColor;

	public bool closed = true;
	public bool opened = false;

	public int state = 0;

	public bool opening = false;
	public bool closing = false;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
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
				if (closed) {
					opening = true;
				} else if (opened) {
					closing = true;
				}
				if (opening) {
					closed = false;
					state += 1;
					if (state == 3) {
						opened = true;
						opening = false;
					}
				} else if (closing) {
					opened = false;
					Debug.Log ("state " + state.ToString());
					state -= 1;
					if (state == 0) {
						closing = false;
						closed = true;
					}
				}
			}
			if (timer > 900) {
				anim.SetTrigger ("unposess");
				timer = 0;
				posessed = false;
				jinn.GetComponent<JinnScript> ().posessing = false;
				gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
			}
		} else {
//			Debug.Log ("state " + state.ToString());
			if (opening) {
				closed = false;
				state += 1;
				if (state == 3) {
					opened = true;
					opening = false;
				}
			} else if (closing) {
				opened = false;
				Debug.Log ("state " + state.ToString());
				state -= 1;
				if (state == 0) {
					closing = false;
					closed = true;
				}
			}
//			anim.SetInteger ("state", state);
		}
		anim.SetInteger ("state", state);
			
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag("jinn")) {
			info.gameObject.SetActive (false);
			info.gameObject.GetComponent<JinnScript> ().posessing = true;
			posessed = true;

			anim.SetTrigger ("posess");
//			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 30, 255);
		}
	}
		
}
