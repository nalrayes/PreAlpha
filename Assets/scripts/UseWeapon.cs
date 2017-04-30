using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour {

	public GameObject weaponUp;
	public GameObject weaponDown;
	public GameObject weaponLeft;
	public GameObject weaponRight;

	public GameObject lastWeapon;

	public KeyCode lastDirection;

	int timer;
	int FRAME_LIMIT = 20;
	int attackTimer;

	public bool attackCondition;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		attackTimer = 0;
		timer = 0;
		weaponUp = gameObject.transform.FindChild("WeaponUp").gameObject;
		weaponDown = gameObject.transform.FindChild("WeaponDown").gameObject;
		weaponLeft = gameObject.transform.FindChild("WeaponLeft").gameObject;
		weaponRight = gameObject.transform.FindChild("WeaponRight").gameObject;

		gameObject.GetComponent<EnemyScript> ().weaponUp = weaponUp;
		gameObject.GetComponent<EnemyScript> ().weaponDown = weaponDown;
		gameObject.GetComponent<EnemyScript> ().weaponLeft = weaponLeft;
		gameObject.GetComponent<EnemyScript> ().weaponRight = weaponRight;

		weaponUp.SetActive (false);
		weaponDown.SetActive (false);
		weaponLeft.SetActive (false);
		weaponRight.SetActive (false);

		lastWeapon = weaponUp;

		lastDirection = KeyCode.UpArrow;

		attackCondition = false;

	}
	
	// Update is called once per frame
	void Update () {
//		timer += 1;
//		Debug.Log (attackCondition);
		if (attackCondition) {
			timer += 1;
			lastWeapon.SetActive (false);

			if (timer > FRAME_LIMIT) {
				lastWeapon.SetActive (false);
				timer = 0;
			} else {
				switch (lastDirection) {
				case KeyCode.DownArrow:
					lastWeapon = weaponDown;

//					anim.SetInteger ("direction", -1);

					break;
				case KeyCode.UpArrow:
					lastWeapon = weaponUp;

//					anim.SetInteger ("direction", 1);

					break;
				case KeyCode.LeftArrow:
					lastWeapon = weaponLeft;

//					anim.SetInteger ("direction", 2);

					break;
				case KeyCode.RightArrow:
					lastWeapon = weaponRight;

//					anim.SetInteger ("direction", -2);

					break;
				default:
					lastWeapon = weaponUp;

//					anim.SetInteger ("direction", 1);

					break;
				}
				anim.SetTrigger ("attack");
				lastWeapon.SetActive (true);

			}
		} else if (gameObject.GetComponent<EnemyScript> ().posessed) {
			attackTimer += 1;
			if (Input.GetKey (KeyCode.Q)) {
				lastWeapon.SetActive (false);
				attackTimer = 0;

				if (attackTimer > FRAME_LIMIT) {
					attackTimer = 0;
				} else {
					switch (lastDirection) {
					case KeyCode.DownArrow:
						lastWeapon = weaponDown;

						anim.SetInteger ("direction", -1);

						break;
					case KeyCode.UpArrow:
						lastWeapon = weaponUp;

						anim.SetInteger ("direction", 1);

						break;
					case KeyCode.LeftArrow:
						lastWeapon = weaponLeft;

						anim.SetInteger ("direction", 2);

						break;
					case KeyCode.RightArrow:
						lastWeapon = weaponRight;

						anim.SetInteger ("direction", -2);

						break;
					default:
						lastWeapon = weaponUp;

						anim.SetInteger ("direction", 1);

						break;
					}
					anim.SetTrigger ("attack as jinn");
					lastWeapon.SetActive (true);

				}
			}

		} else {
			timer = 0;
			lastWeapon.SetActive (false);
		}

		
	}
}
