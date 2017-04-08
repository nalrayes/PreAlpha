using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	GameObject jinn;
	public bool walking = false;
	public bool summoning = false;
	public int directionValue = 0;
	bool canSummon;
	GameObject summoner;
	GameObject posessed;
//
//	GameObject jinnWeaponUp;
//	GameObject jinnWeaponDown;
//	GameObject jinnWeaponLeft;
//	GameObject jinnWeaponRight;
//
//	GameObject lastWeapon;

	JinnScript jinnScript;

	KeyCode lastDirection;

	float timer;
	float summoningTimer;
	float FRAME_LIMIT;
	int SUMMONING_LIMIT;
	int SUMMONING_COOLDOWN;

	private Animator anim;
	private Animator feetAnim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
//		feetAnim = this.GetComponentInChildren<Animator> ();
		jinn = GameObject.Find ("Circle");
		jinn.SetActive(false);
		jinnScript = jinn.GetComponent<JinnScript> ();
		jinnScript.posessing = false;

		summoner = GameObject.Find("Summoner");


//		jinnWeaponUp = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponUp").gameObject;
//		jinnWeaponDown = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponDown").gameObject;
//		jinnWeaponLeft = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponLeft").gameObject;
//		jinnWeaponRight = jinn.transform.Find("Weapons").gameObject.transform.Find("WeaponRight").gameObject;
//
//		jinnWeaponUp.SetActive (false);
//		jinnWeaponDown.SetActive (false);
//		jinnWeaponLeft.SetActive (false);
//		jinnWeaponRight.SetActive (false);
//
//		lastWeapon = jinnWeaponUp;

		timer = 0;
		summoningTimer = 0;
		canSummon = true;

		FRAME_LIMIT = 20;

		SUMMONING_LIMIT = 300;

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
			if (summoningTimer % 50 == 0)
				gameObject.GetComponent<PropertyScript> ().changeMana (-1);
			if (gameObject.GetComponent<PropertyScript> ().currentMana < 0) {
				jinn.SetActive (false);
				return;
			}
			summonerSpeed = 3.0f;
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
//				lastWeapon.SetActive (false);
				timer = 0;
			}
				
//			if (Input.GetKey (KeyCode.Q)) {
//				lastWeapon.SetActive (false);
//				timer = 0;
//				
//				if (timer > FRAME_LIMIT) {
//					timer = 0;
//				} else {
//					switch (lastDirection) {
//					case KeyCode.DownArrow:
//						lastWeapon = jinnWeaponDown;
//
//						break;
//					case KeyCode.UpArrow:
//						lastWeapon = jinnWeaponUp;
//
//						break;
//					case KeyCode.LeftArrow:
//						lastWeapon = jinnWeaponLeft;
//
//						break;
//					case KeyCode.RightArrow:
//						lastWeapon = jinnWeaponRight;
//
//						break;
//					default:
//						lastWeapon = jinnWeaponUp;
//					
//						break;
//					}
//					lastWeapon.SetActive (true);

//				}
//			}

			if (summoningTimer > SUMMONING_LIMIT) {
				summoningTimer = 0;
				canSummon = false;
				jinn.SetActive (false);
				summoning = false;
			}
				
		} else if (jinnScript.posessing) {
			if (summoningTimer % 20 == 0)
			if (summoningTimer % 30 == 0)
				gameObject.GetComponent<PropertyScript> ().changeMana (-1);
			if (gameObject.GetComponent<PropertyScript> ().currentMana < 0) {
				jinnScript.posessing = false;
				return;
			}
			summonerSpeed = 1f;
			summoningTimer += 2;
		} else {
			summonerSpeed = 4.0f;
//			lastWeapon.SetActive (false);
			if (canSummon) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					if (gameObject.GetComponent<PropertyScript>().currentMana > 0) {
						summoning = true;
						jinn.SetActive (true);
						Vector3 rightOf = new Vector3 (1.2f, 0f);
						jinn.transform.position = summoner.transform.position + rightOf;
						jinn.transform.rotation = summoner.transform.rotation;
					}
				}
			} else {
				summoningTimer += 1;
				if (summoningTimer > SUMMONING_COOLDOWN) {
					canSummon = true;
					summoningTimer = 0;
				}
			}
		}
//		summonerSpeed = 100.0f;
		if (Input.GetKey (KeyCode.D)) {
//			Debug.Log ("D");
			anim.SetInteger ("direction", 2);
			directionValue = 2;
//			feetAnim.SetInteger ("direction", 2);
			summoner.transform.position += Vector3.right * summonerSpeed * Time.deltaTime;
			walking = true;
		} else if (Input.GetKey (KeyCode.A)) {
			anim.SetInteger ("direction", -2);
			directionValue = -2;
//			feetAnim.SetInteger ("direction", -2);
			summoner.transform.position += Vector3.left * summonerSpeed * Time.deltaTime;
			walking = true;
		} else if (Input.GetKey (KeyCode.W)) {
			anim.SetInteger ("direction", 1);
			directionValue = 1;
//			feetAnim.SetInteger ("direction", 1);
			summoner.transform.position += Vector3.up * summonerSpeed * Time.deltaTime;
			walking = true;
		} else if (Input.GetKey (KeyCode.S)) {
			anim.SetInteger ("direction", -1);
			directionValue = -1;
//			feetAnim.SetInteger ("direction", -1);
			summoner.transform.position += Vector3.down * summonerSpeed * Time.deltaTime;
			walking = true;
		} else {
			walking = false;
		}

		if (walking) {
			anim.SetBool ("moving", true);
//			feetAnim.SetBool ("moving", true);
		} else {
			anim.SetBool("moving", false);
//			feetAnim.SetBool ("moving", false);
		}
	}

	public bool getSummoning() {
		return summoning;
	}
}
