using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour {

	GameObject weaponUp;
	GameObject weaponDown;
	GameObject weaponLeft;
	GameObject weaponRight;

	GameObject lastWeapon;

	public KeyCode lastDirection;

	int timer;
	int FRAME_LIMIT = 20;

	public bool attackCondition;
	// Use this for initialization
	void Start () {
		weaponUp = gameObject.transform.FindChild("WeaponUp").gameObject;
		weaponDown = gameObject.transform.FindChild("WeaponDown").gameObject;
		weaponLeft = gameObject.transform.FindChild("WeaponLeft").gameObject;
		weaponRight = gameObject.transform.FindChild("WeaponRight").gameObject;

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
//		Debug.Log (attackCondition);
		if (attackCondition) {
			lastWeapon.SetActive (false);

			if (timer > FRAME_LIMIT) {
				lastWeapon.SetActive (false);
				timer = 0;
			} else {
				switch (lastDirection) {
				case KeyCode.DownArrow:
					lastWeapon = weaponDown;

					break;
				case KeyCode.UpArrow:
					lastWeapon = weaponUp;

					break;
				case KeyCode.LeftArrow:
					lastWeapon = weaponLeft;

					break;
				case KeyCode.RightArrow:
					lastWeapon = weaponRight;

					break;
				default:
					lastWeapon = weaponUp;

					break;
				}
				lastWeapon.SetActive (true);

			}
		} else {
			timer = 0;
			lastWeapon.SetActive (false);
		}

		
	}
}
