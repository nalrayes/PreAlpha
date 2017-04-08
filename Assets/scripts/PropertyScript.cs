﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyScript : MonoBehaviour {
	
	public int MAX_HEALTH;
	public int MAX_MANA;

	public int currentMana;
	public int currentHealth;

	public AudioClip getHit;


	// Use this for initialization
	void Start () {
		currentHealth = MAX_HEALTH;
		currentMana = MAX_MANA;
		printall ();
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth == 0) {
			// death state? rn just die.
			gameObject.SetActive(false);
		}
	}

	public void changeHealth(int amt) {
		if (currentHealth + amt > MAX_HEALTH) {
			currentHealth = MAX_HEALTH;
		} else if (currentHealth + amt < 0) {
			currentHealth = 0;
		} else {
			currentHealth += amt;
		}
		printall ();
	}

	public void changeMana(int amt) {
		if (currentMana + amt > MAX_MANA) {
			currentMana = MAX_MANA;
		} else if (currentMana + amt < 0) {
			currentMana = 0;
		} else {
			currentMana += amt;
		}
		printall ();
	}

	void OnCollisionEnter2D(Collision2D item)  {
//		Debug.Log ("collided!");
		if (item.gameObject.CompareTag ("health")) {
			// changeHealth by certain amount, ideally by something like item.gameObject.GetComponent<increaseHealthScript>().amount
		} else if (item.gameObject.CompareTag ("weapon") || item.gameObject.CompareTag("enemy weapon")) {
			int damage = item.gameObject.GetComponent<DamageScript> ().damage;
			changeHealth (-1 * damage);
			Debug.Log ("ow");

			SoundManager.instance.PlaySingle (getHit);

		} else if (item.gameObject.CompareTag ("mana")) {
			// change mana
		}
	}

	void printall(){
		Debug.Log ("Health: " + currentHealth + "/" + MAX_HEALTH);
		Debug.Log ("Mana: " + currentMana + "/" + MAX_MANA);
	}
}
