using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveWeaponScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag ("jinn")) {
			info.gameObject.transform.Find ("Weapons").gameObject.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
