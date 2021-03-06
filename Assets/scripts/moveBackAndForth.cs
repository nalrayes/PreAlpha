﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackAndForth : MonoBehaviour {
	public Vector3 direction;
	Vector3 originalPos;

	bool posessed = false;
	int timer = 0;
	Color32 originalColor;

	Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		anim.SetBool ("not stopped", true);
		originalPos = transform.localPosition;
//		direction = Vector3.up;

		originalColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (originalPos.y);
		if (!posessed) {
			if (direction.y == 1) {
				if (transform.localPosition.y > -1 * originalPos.y) {
					direction = -1 * direction;
				}
			} else {
				if (transform.localPosition.y < originalPos.y) {
					direction = -1 * direction;
				}
			}
			gameObject.transform.position += 5f * direction * Time.deltaTime;
		} else {
		timer++;
		if (timer > 90) {
			gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
			posessed = false;
			timer = 0;
		}
	}

	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag("jinn")) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 30, 255); 
			posessed = true;
			info.gameObject.SetActive (false);
		} else if (info.gameObject.CompareTag("summoner")) {
			//take dmg
		}
	}
}
