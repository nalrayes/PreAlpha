using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replenishShit : MonoBehaviour {
	int timer;

	Animator anim;

	public AudioClip use;
	public AudioClip available;
	public AudioClip unavailable;

	int endTimer = 0;

	// Use this for initialization
	void Start () {
		timer = 2001;

		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == 2000) {
			anim.SetTrigger ("fill");
			SoundManager.instance.PlaySingle (available);
			timer++;
			endTimer = 0;
		} 
		if (timer < 2000) {
			if (endTimer <= 20) {	
				endTimer++;
			} 
			timer++;
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		
		if (info.gameObject.CompareTag ("summoner")) {
			if (timer >= 2000) {
				SoundManager.instance.PlaySingle (use);
				info.gameObject.GetComponent<PropertyScript> ().changeMana (5);
				info.gameObject.GetComponent<PropertyScript> ().changeHealth (5);
				timer = 0;
				anim.SetTrigger ("empty");
			} else if (endTimer > 20) {
				SoundManager.instance.PlaySingle (unavailable);
			}
		} 
	}
}
