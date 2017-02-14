using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	GameObject summoner;
	public Vector2 directionToMove;
	float projectileSpeed;
	// Use this for initialization
	void Start () {
//		summoner = GameObject.FindGameObjectWithTag ("summoner");
		projectileSpeed = 5f;
	}

	// Update is called once per frame
	void Update () {
//		RangedAttack rangedAttack = summoner.GetComponent<RangedAttack> ();
//		direction = rangedAttack.direction;

		transform.position += (Vector3)directionToMove * projectileSpeed * Time.deltaTime;
	}

//	void OnCollisionEnter2D(Collision2D collisionInfo) {
////		Destroy(gameObject);
//	}
}
