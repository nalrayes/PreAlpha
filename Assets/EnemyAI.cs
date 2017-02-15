﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	bool playerVisible;
	Vector3 originalPosition;

	float speed = 5f;
	// Use this for initialization

	GameObject summoner;
	void Start () {
		summoner = GameObject.FindGameObjectWithTag ("summoner");
		playerVisible = false;
		originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Vector3.Distance (summoner.transform.position, transform.position));
//		moveToPlayer ();
		if (Vector3.Distance (summoner.transform.position, transform.position) <= 10f) {
			moveToPlayer ();
		}
	}
	/*
	 * move to player vector position
	 * if in attack range stop and attack at player vector position
	 * look for player, if not found return to original position
	 */
	void moveToPlayer () {
		transform.position = Vector3.MoveTowards (transform.position, summoner.transform.position, 2*Time.deltaTime);
		// if within range, attack
		if (Vector3.Distance (summoner.transform.position, transform.position) > 2) {
			//attack
		}
	}

	void moveTo(Vector3 location) {
		/*
		 * get difference vector
		 * move that difference
		 */
	}
}
