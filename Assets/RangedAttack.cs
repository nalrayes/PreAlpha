﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

	public GameObject projectilePrefab;

	JinnScript jinnScript;
	MoveScript moveScript;
	public GameObject jinn;
	GameObject summoner;

	public Vector2 direction;
	bool canAttack;
	int timer = 0;

	int LIMIT = 10;

	// Use this for initialization
	void Start () {
		summoner = GameObject.FindGameObjectWithTag("summoner");
		moveScript = GetComponent<MoveScript> ();
//		Debug.Log (moveScript);
		canAttack = true;

	}

	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown(KeyCode.R)) {
//			// Let's move towards the mouse.
//			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			Vector2 toMouseDir = ((Vector2)mouseWorldPos-(Vector2)transform.position).normalized;
//
//			GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
//			newProjectile.transform.position = transform.position;
//			newProjectile.GetComponent<ProjectileScript>().directionToMove = (Vector3)toMouseDir;
//		}
		if (!moveScript.getSummoning()) {
			if (canAttack) {
				if (Input.GetKey(KeyCode.DownArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.down;
				} else if (Input.GetKey(KeyCode.UpArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.up;;
				} else if (Input.GetKey(KeyCode.LeftArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.left;;
				} else if (Input.GetKey(KeyCode.RightArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.right;
				}
				canAttack = false;
			} else {
				timer += 1;
				if (timer > LIMIT) {
					canAttack = true;
					timer = 0;
				}
			}
		}
	}
}
