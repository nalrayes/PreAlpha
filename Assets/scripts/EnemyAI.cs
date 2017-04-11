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

	public int direction = 0;
	public bool moving = false;

	public Animator anim;

	void Start () {
		summoner = GameObject.FindGameObjectWithTag ("summoner");
		playerVisible = false;
		originalPosition = this.transform.position;

		weaponScript = this.GetComponent<UseWeapon> ();

		anim = this.GetComponent<Animator> ();
	}
		
	
	// Update is called once per frame	
	void Update () {
//		Debug.Log(Vector3.Distance (summoner.transform.position, transform.position));
		if (summoner.activeSelf) {
			timer++;
			float dist = Vector3.Distance (summoner.transform.position, transform.position);
			if (!gameObject.GetComponent<EnemyScript>().posessed) {
				if (dist <= 10f && dist > 1.5f) {
					moveToPlayer ();
					if (timer > LIMIT) {
						weaponScript.attackCondition = false;
						if (timer > LIMIT2)
							timer = 0;
					}
					anim.SetBool ("attack", false);
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
						
						direction = 1;

						weaponScript.lastDirection = KeyCode.UpArrow;
					} else if (difference == Vector3.down) {
						
						direction = -1;

						weaponScript.lastDirection = KeyCode.DownArrow;
					} else if (difference == Vector3.left) {
						
						direction = -2;

						weaponScript.lastDirection = KeyCode.LeftArrow;
					} else if (difference == Vector3.right) {
						
						direction = 2;

						weaponScript.lastDirection = KeyCode.RightArrow;
					}

				} else {
					//return to original position
					Vector3 directionToMove = transform.position - originalPosition;
					directionToMove.x = Mathf.Round (directionToMove.x);
					directionToMove.y = Mathf.Round (directionToMove.y);

					if (directionToMove == Vector3.up) {
						moving = true;
						direction = 1;
					} else if (directionToMove == Vector3.down) {
						moving = true;
						direction = -1;
					} else if (directionToMove == Vector3.left) {
						moving = true;
						direction = -2;
					} else if (directionToMove == Vector3.right) {
						moving = true;
						direction = 2;
					}
						

					transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed*Time.deltaTime);
					moving = true;
					if (transform.position == originalPosition) {
						moving = false;
					}

					anim.SetInteger ("direction", direction);
					anim.SetBool ("moving", moving);
					anim.SetBool ("attack", false);
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
		Vector3 directionToMove = transform.position - summoner.transform.position;
		directionToMove.x = Mathf.Round (directionToMove.x);
		directionToMove.y = Mathf.Round (directionToMove.y);

		if (directionToMove == Vector3.up) {
			moving = true;
			direction = 1;
		} else if (directionToMove == Vector3.down) {
			moving = true;
			direction = -1;
		} else if (directionToMove == Vector3.left) {
			moving = true;
			direction = -2;
		} else if (directionToMove == Vector3.right) {
			moving = true;
			direction = 2;
		}

		anim.SetInteger ("direction", direction);
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("enemy attack up") || anim.GetCurrentAnimatorStateInfo (0).IsName ("enemy attack down")
		    || anim.GetCurrentAnimatorStateInfo (0).IsName ("enemy attack left") || anim.GetCurrentAnimatorStateInfo (0).IsName ("enemy attack right")) {
			anim.SetBool ("moving", false);
		} else {
			anim.SetBool ("moving", moving);
			transform.position = Vector3.MoveTowards (transform.position, summoner.transform.position, speed*Time.deltaTime);
		}
		// if within range, attack
	}

	void onCollisionEnter2D(Collision2D collided) {
		if (collided.gameObject.CompareTag("summoner")){
//			summoner.SetActive(false);
		}
	}
}
