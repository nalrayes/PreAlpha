using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRangedAttack : MonoBehaviour {
	float timer;
	public Vector2 direction;

	public GameObject projectilePrefab;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer == 30) {
//			Debug.Log (timer);
			GameObject projectile = Instantiate (projectilePrefab) as GameObject;
			projectile.transform.position = this.transform.position + (Vector3) direction;
			projectile.GetComponent<ProjectileScript> ().directionToMove = direction;
			timer = 0;
		}
	}
}
