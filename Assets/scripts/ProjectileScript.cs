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
		projectileSpeed = 8f;
		Vector2 direction = directionToMove;
		Debug.Log (Vector2.left);
		if (direction == Vector2.left) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180));
		} else if (direction == Vector2.right) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		} else if (direction == Vector2.up) {
			//			Debug.Log ("yueaj");
			transform.rotation = Quaternion.Euler (new Vector3(0, 0,  90));
		} else if (direction == Vector2.down) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -90));
		}
	}

	// Update is called once per frame
	void Update () {
//		RangedAttack rangedAttack = summoner.GetComponent<RangedAttack> ();
//		direction = rangedAttack.direction;
		transform.position += (Vector3)directionToMove * projectileSpeed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collisionInfo) {
//		Debug.Log ("Collided!");
		Destroy(gameObject);
	}
}
