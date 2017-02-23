using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	bool playerVisible;
	Vector3 originalPosition;

	float speed = 2.5f;
	// Use this for initialization

	GameObject summoner;

	float timer = 0;
	float LIMIT = 20;
	float LIMIT2 = 25;

	UseWeapon weaponScript;

	void Start () {
		summoner = GameObject.FindGameObjectWithTag ("summoner");
		playerVisible = false;
		originalPosition = this.transform.position;

		weaponScript = this.GetComponent<UseWeapon> ();
	}
		
	
	// Update is called once per frame	
	void Update () {
//		Debug.Log(Vector3.Distance (summoner.transform.position, transform.position));
		if (summoner.activeSelf) {
			timer++;
			float dist = Vector3.Distance (summoner.transform.position, transform.position);
			if (dist <= 10f && dist > 1.5f) {
				moveToPlayer ();
				if (timer > LIMIT) {
					weaponScript.attackCondition = false;
					if (timer > LIMIT2) 
						timer = 0;
				}
			} else if (dist <= 1.5f) {
				if (timer > LIMIT) {
					if (timer > LIMIT2) {
						timer = 0;
					}
					weaponScript.attackCondition = false;
					return;
				}
				
				weaponScript.attackCondition = true;

				Vector3 difference = summoner.transform.position - transform.position;
				difference.x = Mathf.Round (difference.x);
				difference.y = Mathf.Round (difference.y);
				if (difference == Vector3.up) {
					weaponScript.lastDirection = KeyCode.UpArrow;
				} else if (difference == Vector3.down) {
					weaponScript.lastDirection = KeyCode.DownArrow;
				} else if (difference == Vector3.left) {
					weaponScript.lastDirection = KeyCode.LeftArrow;
				} else if (difference == Vector3.right) {
					weaponScript.lastDirection = KeyCode.RightArrow;
				}
			} else {
				if (timer > LIMIT) {
					weaponScript.attackCondition = false;
					if (timer > LIMIT2) {
						timer = 0;
					}
				}
			}
		}
	}
	/*
	 * move to player vector position
	 * if in attack range stop and attack at player vector position
	 * look for player, if not found return to original position
	 */
	void moveToPlayer () {
		transform.position = Vector3.MoveTowards (transform.position, summoner.transform.position, speed*Time.deltaTime);
		// if within range, attack
	}

	void onCollisionEnter2D(Collision2D collided) {
		if (collided.gameObject.CompareTag("summoner")){
//			summoner.SetActive(false);
		}
	}
}
