using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRightConstant : MonoBehaviour {

	GameObject summoner;
	Vector2 direction;
	float projectileSpeed;
	// Use this for initialization
	void Start () {
		summoner = GameObject.FindGameObjectWithTag ("summoner");
		projectileSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		RangedAttack rangedAttack = summoner.GetComponent<RangedAttack> ();
		direction = rangedAttack.direction;

		transform.position += (Vector3)direction * projectileSpeed * Time.deltaTime;
	}
}
