using System.Collections;
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

	Animator anim;

	public AudioClip attackSound;

	// Use this for initialization
	void Start () {
		summoner = GameObject.FindGameObjectWithTag("summoner");
		moveScript = GetComponent<MoveScript> ();
//		Debug.Log (moveScript);
		canAttack = true;

		anim = GetComponent<Animator> ();
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

					anim.SetTrigger ("attack");
					anim.SetInteger ("direction", -1);

					SoundManager.instance.PlaySingle(attackSound);
				} else if (Input.GetKey(KeyCode.UpArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.up;

					anim.SetTrigger ("attack");
					anim.SetInteger ("direction", 1);

					SoundManager.instance.PlaySingle(attackSound);
				} else if (Input.GetKey(KeyCode.LeftArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.left;

					anim.SetTrigger ("attack");
					anim.SetInteger ("direction", -2);

					SoundManager.instance.PlaySingle(attackSound);
				} else if (Input.GetKey(KeyCode.RightArrow)) {
					GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
					projectile.transform.position = this.transform.position;
					projectile.GetComponent<ProjectileScript> ().directionToMove = Vector2.right;

					anim.SetTrigger ("attack");
					anim.SetInteger ("direction", 2);

					SoundManager.instance.PlaySingle(attackSound);
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
