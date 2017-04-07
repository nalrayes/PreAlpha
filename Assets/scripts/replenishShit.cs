using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replenishShit : MonoBehaviour {
	int timer;

	Animator anim;
	// Use this for initialization
	void Start () {
		timer = 501;

		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == 500) {
			anim.SetTrigger ("fill");
			timer++;
		} 
		if (timer < 500) {
			timer++;
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (timer > 500) {
			if (info.gameObject.CompareTag ("summoner")) {
				info.gameObject.GetComponent<PropertyScript> ().changeMana (5);
				info.gameObject.GetComponent<PropertyScript> ().changeHealth (5);
				timer = 0;
				anim.SetTrigger ("empty");
			}
		}
	}
}
