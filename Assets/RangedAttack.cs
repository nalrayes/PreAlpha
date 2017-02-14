using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

	public GameObject projectilePrefab;

	JinnScript jinnScript;
	public GameObject jinn;
	GameObject summoner;

	public Vector2 direction;

	float projectileSpeed;
	// Use this for initialization
	void Start () {
		summoner = this.gameObject;
		jinn = summoner.GetComponent<MoveScript> ().jinn;
		jinnScript = jinn.GetComponent<JinnScript> ();

		projectileSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			// Let's move towards the mouse.
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 toMouseDir = ((Vector2)mouseWorldPos-(Vector2)transform.position).normalized;

			GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
			newProjectile.transform.position = transform.position;
			newProjectile.GetComponent<ProjectileScript>().directionToMove = toMouseDir;
		}
		if (false) {
			if (Input.GetKey(KeyCode.DownArrow)) {
				GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
				direction = Vector2.down;
				projectile.transform.position = this.transform.position;
				projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
			} else if (Input.GetKey(KeyCode.UpArrow)) {
				GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
				direction = Vector2.up;
				projectile.transform.position = this.transform.position;
				projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
			} else if (Input.GetKey(KeyCode.LeftArrow)) {
				GameObject projectile = Instantiate (projectilePrefab) as GameObject;
				direction = Vector2.left;
				projectile.transform.position = this.transform.position;
				projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				GameObject projectile = Instantiate (projectilePrefab) as GameObject;	
				direction = Vector2.right;
				projectile.transform.position = this.transform.position;
				projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
			}

		}
	}
}
