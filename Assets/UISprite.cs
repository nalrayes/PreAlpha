using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISprite : MonoBehaviour {

	GameObject summoner;
	GameObject manaBar;
	GameObject healthBar;

	public float currentScaleManax;
	public float currentScaleManay;

	public float currentScaleHealthx;
	public float currentScaleHealthy;

	public float maxScaleManax;
	public float maxScaleHealthx;

	PropertyScript summonerPropScript;

	public float amountToSubtractMana;
	public float amountToSubtractHealth;
	// Use this for initialization
	void Start () {
		summoner = GameObject.Find ("Summoner");
		manaBar = GameObject.Find ("Mana Bar");
		healthBar = GameObject.Find ("Health Bar");

		currentScaleManax = manaBar.transform.localScale.x;
		currentScaleManay = manaBar.transform.localScale.y;

		currentScaleHealthx = healthBar.transform.localScale.x;
		currentScaleHealthy = healthBar.transform.localScale.y;

		maxScaleManax = currentScaleManax;
		maxScaleHealthx = currentScaleHealthx;

		summonerPropScript = summoner.GetComponent<PropertyScript> ();

		amountToSubtractMana = currentScaleManax * 1/summonerPropScript.MAX_MANA;
		amountToSubtractHealth = currentScaleHealthx * 1/summonerPropScript.MAX_HEALTH;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void lowerMana(float amt) {
		manaBar.transform.localScale = new Vector3(currentScaleManax - amountToSubtractMana, currentScaleManay, 1);
	}

	public void lowerHealth() {
		
		healthBar.transform.localScale = new Vector3(currentScaleHealthx - amountToSubtractHealth, currentScaleHealthy, 1);
	}

	public void recoverMana(float amt) {
		if (currentScaleManax + maxScaleManax * amt > maxScaleManax) {
			currentScaleManax = maxScaleManax;
		} else if (currentScaleManax + maxScaleManax * amt < 0) {
			currentScaleManax = 0;
		} else {
			currentScaleManax = currentScaleManax + maxScaleManax * amt;
			Debug.Log ("that's right im in it");
		}
		manaBar.transform.localScale = new Vector3 (currentScaleManax, currentScaleManay, 1);
	}

	public void recoverHealth(float amt) {
		if (currentScaleHealthx + maxScaleHealthx * amt > maxScaleHealthx) {
			currentScaleHealthx = maxScaleHealthx;
			healthBar.transform.localScale = new Vector3 (maxScaleHealthx, currentScaleHealthy, 1);
		} else if (currentScaleHealthx + maxScaleHealthx < 0) {
			currentScaleHealthx = 0;
		} else {
			currentScaleHealthx = currentScaleHealthx + maxScaleHealthx * amt;
			healthBar.transform.localScale = new Vector3 (currentScaleHealthx + maxScaleHealthx * amt, currentScaleHealthy, 1);
		}
	}
}
