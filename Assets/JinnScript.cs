﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinnScript : MonoBehaviour {
	public bool posessing;
	// Use this for initialization
	void Start ()
	{
		transform.Find ("Weapons").gameObject.SetActive (false);
		posessing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		
	}
}
