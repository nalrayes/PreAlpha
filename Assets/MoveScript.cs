using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	GameObject jinn;
	public bool summoning = false;
	bool canSummon;
	GameObject summoner;
	GameObject posessed;

	GameObject jinnWeaponUp;
	GameObject jinnWeaponDown;
	GameObject jinnWeaponLeft;
	GameObject jinnWeaponRight;

	GameObject lastWeapon;

	JinnScript jinnScript;

	KeyCode lastDirection;

	float timer;
	float summoningTimer;
	float FRAME_LIMIT;
	int SUMMONING_LIMIT;
	int SUMMONING_COOLDOWN;

	// Use this for initialization
	void Start () {
		jinn = GameObject.Find ("Circle");
		jinn.SetActive(false);
		jinnScript = jinn.GetComponent<JinnScript> ();
		jinnScript.posessing = false;

		summoner = GameObject.Find("Square");


		jinnWeaponUp = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponUp").gameObject;
		jinnWeaponDown = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponDown").gameObject;
		jinnWeaponLeft = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponLeft").gameObject;
		jinnWeaponRight = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponRight").gameObject;

		jinnWeaponUp.SetActive (false);
		jinnWeaponDown.SetActive (false);
		jinnWeaponLeft.SetActive (false);
		jinnWeaponRight.SetActive (false);

		lastWeapon = jinnWeaponUp;

		timer = 0;
		summoningTimer = 0;
		canSummon = true;

		FRAME_LIMIT = 20;

		SUMMONING_LIMIT = 200;

		SUMMONING_COOLDOWN = 100;

		lastDirection = KeyCode.UpArrow;
	}

	// Update is called once per frame
	void Update () {
		float jinnSpeed = 4.0f;
		float summonerSpeed;
//		Debug.Log (summoningTimer);


		if (jinn.activeSelf) {
			timer += 1;
			summoningTimer += 1;
			summonerSpeed = 2.0f;
			if (Input.GetKeyDown (KeyCode.Space)) {
				jinn.SetActive (false);
				summoning = false;
				summonerSpeed = 4.0f;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				lastDirection = KeyCode.RightArrow;
				jinn.transform.position += Vector3.right * jinnSpeed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				lastDirection = KeyCode.LeftArrow;
				jinn.transform.position += Vector3.left * jinnSpeed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				lastDirection = KeyCode.UpArrow;
				jinn.transform.position += Vector3.up * jinnSpeed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				lastDirection = KeyCode.DownArrow;
				jinn.transform.position += Vector3.down * jinnSpeed * Time.deltaTime;
			}

			if (timer > FRAME_LIMIT) {
				lastWeapon.SetActive (false);
				timer = 0;
			}
				
			if (Input.GetKey (KeyCode.Q)) {
				lastWeapon.SetActive (false);
				timer = 0;
				
				if (timer > FRAME_LIMIT) {
					timer = 0;
				} else {
					switch (lastDirection) {
					case KeyCode.DownArrow:
						lastWeapon = jinnWeaponDown;

						break;
					case KeyCode.UpArrow:
						lastWeapon = jinnWeaponUp;

						break;
					case KeyCode.LeftArrow:
						lastWeapon = jinnWeaponLeft;

						break;
					case KeyCode.RightArrow:
						lastWeapon = jinnWeaponRight;

						break;
					default:
						lastWeapon = jinnWeaponUp;
					
						break;
					}
					lastWeapon.SetActive (true);

				}
			}

			if (summoningTimer > SUMMONING_LIMIT) {
				summoningTimer = 0;
				canSummon = false;
				jinn.SetActive (false);
				summoning = false;
			}
				
		} else if (jinnScript.posessing) {
			summonerSpeed = 0f;
			summoningTimer += 2;
		} else {
			summonerSpeed = 4.0f;
			lastWeapon.SetActive (false);
			if (canSummon) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					summoning = true;
					jinn.SetActive (true);
					gameObject.GetComponent<PropertyScript> ().changeMana (-1);
					Vector3 rightOf = new Vector3 (1.2f, 0f);
					jinn.transform.position = summoner.transform.position + rightOf;
					jinn.transform.rotation = summoner.transform.rotation;
				}
			} else {
				summoningTimer += 1;
				if (summoningTimer > SUMMONING_COOLDOWN) {
					canSummon = true;
					summoningTimer = 0;
				}
			}
		}
		if (Input.GetKey(KeyCode.D)){
			summoner.transform.position += Vector3.right * summonerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)){
			summoner.transform.position += Vector3.left* summonerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W)){
			summoner.transform.position += Vector3.up * summonerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)){
			summoner.transform.position += Vector3.down * summonerSpeed * Time.deltaTime;
		}
	}

	public bool getSummoning() {
		return summoning;
	}
}
