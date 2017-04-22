using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinnScript : MonoBehaviour {
	public bool posessing;
	public GameObject posessingObject;
	// Use this for initialization
	public Animator anim;
	void Start ()
	{
//		transform.Find ("Weapons").gameObject.SetActive (false);
		posessing = false;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onDisable() {
		GameObject.Find ("Summoner").GetComponent<MoveScript> ().summoning = false;
	}

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		posessingObject = collisionInfo.gameObject;
	}

}
