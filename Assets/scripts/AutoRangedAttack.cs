using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRangedAttack : MonoBehaviour {
	float timer;
	int posessionTimer;
	bool posessed;

	public GameObject projectilePrefab;

	public bool itemGet = false;

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
				if (Input.GetKey(KeyCode.DownArrow)) {
					createAndLaunchProjectile (Vector2.down);
				} else if (Input.GetKey(KeyCode.UpArrow)) {
					createAndLaunchProjectile (Vector2.up);
				} else if (Input.GetKey(KeyCode.LeftArrow)) {
					createAndLaunchProjectile (Vector2.left);
				} else if (Input.GetKey(KeyCode.RightArrow)) {
					createAndLaunchProjectile (Vector2.right);
				}
				if (posessionTimer > 900 || Input.GetKey (KeyCode.Space)) {
					posessed = false;
					posessionTimer = 0;
					jinn.SetActive (true);
					jinn.GetComponent<JinnScript> ().posessing = false;
				}
			} else {
				timer++;
				if (timer == 30) {
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
		projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag("jinn")) {
			posessed = true;
			info.gameObject.SetActive (false);
			info.gameObject.GetComponent<JinnScript> ().posessing = true;
		}
	}
}
