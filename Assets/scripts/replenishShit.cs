using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replenishShit : MonoBehaviour {
	int timer;
	// Use this for initialization
	void Start () {
		timer = 500;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == 500) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (152, 127, 251, 255);
			//keep at 500
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (250, 120, 160, 255);
			timer++;
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (timer == 500) {
			if (info.gameObject.CompareTag ("summoner")) {
				info.gameObject.GetComponent<PropertyScript> ().changeMana (5);
				info.gameObject.GetComponent<PropertyScript> ().changeHealth (5);
				timer = 0;
			}
		}
	}
}
