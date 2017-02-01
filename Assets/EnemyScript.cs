using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	bool posessed = false;

	// Use this for initialization
	void Start () {
		this.tag = "enemy";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (collisionInfo.gameObject.CompareTag("jinn")) {
			posessed = true;
			this.GetComponent<SpriteRenderer> ().color = Color.gray;
		}
	}
}
