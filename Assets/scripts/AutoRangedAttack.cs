using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRangedAttack : MonoBehaviour {
	float timer;
	int posessionTimer;
	bool posessed;

	public GameObject projectilePrefab;

	public bool itemGet = false;

	public float TIME_LIMIT = 60;

	GameObject jinn;

	// Use this for initialization
	void Start () {
		timer = 0;
		posessionTimer = 0;
		jinn = GameObject.FindGameObjectWithTag ("jinn");
	}
	
	// Update is called once per frame
	void Update () {
		if (!itemGet) {
			if (posessed) {
				posessionTimer++;
				if (Input.GetKey(KeyCode.Q)) {
					GetComponent<Animator> ().SetTrigger ("attack");
					createAndLaunchProjectile (Vector2.down);
					createAndLaunchProjectile (Vector2.up);
					createAndLaunchProjectile (Vector2.left);
					createAndLaunchProjectile (Vector2.right);
				}
				if (posessionTimer > 900 || Input.GetKey (KeyCode.Space)) {
					GetComponent<Animator> ().SetBool ("posessed", false);
					posessed = false;
					posessionTimer = 0;
					jinn.SetActive (true);
					jinn.GetComponent<JinnScript> ().posessing = false;
				}
			} else {
				timer++;
				if (timer == TIME_LIMIT) {
					createAndLaunchProjectile (Vector2.up);
					createAndLaunchProjectile (Vector2.down);
					createAndLaunchProjectile (Vector2.right);
					createAndLaunchProjectile (Vector2.left);
					timer = 0;
				}
			}
		}
	}

	void createAndLaunchProjectile(Vector2 direction) {
		GameObject projectile = Instantiate (projectilePrefab) as GameObject;
		projectile.tag = "enemy weapon";
		projectile.layer = 14;
		//				Debug.Log (projectile.layer);
		projectile.transform.position = this.transform.position + (Vector3)direction;
		if (direction == Vector2.right) {
			projectile.transform.rotation = new Quaternion (0, 0, 180, 1);
		} else if (direction == Vector2.up) {
			Debug.Log ("yueaj");
			projectile.transform.rotation = new Quaternion (0, 0,  90, 1);
		} else if (direction == Vector2.down) {
			projectile.transform.rotation = new Quaternion (0, 0, -90, 1);
		}
		projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag("jinn")) {
			posessed = true;
			GetComponent<Animator> ().SetBool ("posessed", true);
			info.gameObject.SetActive (false);
			info.gameObject.GetComponent<JinnScript> ().posessing = true;
		}
	}
}
