using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRangedAttack : MonoBehaviour {
	float timer;
	public Vector2 direction;

	public GameObject projectilePrefab;

	public bool itemGet = false;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!itemGet) {
			timer++;
			if (timer == 30) {
				GameObject projectile = Instantiate (projectilePrefab) as GameObject;
				projectile.tag = "enemy weapon";
				projectile.layer = 14;
//				Debug.Log (projectile.layer);
				projectile.transform.position = this.transform.position + (Vector3)direction;
				projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
				timer = 0;
			}
		}
	}
}
