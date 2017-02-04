using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	bool playerVisible;
	Vector3 originalPosition;
	// Use this for initialization
	void Start () {
		playerVisible = false;
		originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerVisible) {
			this.moveToPlayer ();
		} else {
			//look for player, if within range set true
		}
	}

	void moveToPlayer() {
		/*
		 * move to player vector position
		 * if in attack range stop and attack at player vector position
		 * look for player, if not found return to original position
		 */
	}

	void moveTo(Vector3 location) {
		/*
		 * get difference vector
		 * move that difference
		 */
	}
}
