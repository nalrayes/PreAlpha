using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public bool posessed = false;
	float timer;
	float posessionSpeed;

	GameObject jinn;
	JinnScript jinnScript;

	int TO_KILL = 2;
	int hits;

	int FRAME_LIMIT = 20;
//	int attackTimer;

	GameObject lastWeapon;
	UseWeapon weaponScript;

	public GameObject weaponUp;
	public GameObject weaponDown;
	public GameObject weaponLeft;
	public GameObject weaponRight;

	public KeyCode lastDirection;

	Animator anim;

	PropertyScript summonerProps;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		timer = 0;
//		attackTimer = 0;
		posessionSpeed = 2.0f;

		hits = 0;

		weaponScript= gameObject.GetComponent<UseWeapon> ();
//		weaponUp = weaponScript.weaponUp;
//		weaponRight = weaponScript.weaponRight;
//		weaponLeft = weaponScript.weaponLeft;
//		weaponDown = weaponScript.weaponDown;

		lastWeapon = weaponUp;
		lastDirection = KeyCode.UpArrow;
//		Debug.Log (weaponUp);
//		Debug.Log (weaponDown);
//		Debug.Log (weaponLeft);
//		Debug.Log (weaponRight);
		summonerProps = GameObject.FindGameObjectWithTag ("summoner").gameObject.GetComponent<PropertyScript> ();
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (weaponUp);
//		Debug.Log (weaponDown);
//		Debug.Log (weaponLeft);
//		Debug.Log (weaponRight);
		if (posessed) {
			timer++;
//			attackTimer++;
			if (Input.GetKey(KeyCode.RightArrow)){
				anim.SetBool ("moving", true);
				anim.SetInteger ("direction", 2);

				lastDirection = KeyCode.RightArrow;
				this.transform.position += Vector3.right * posessionSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.LeftArrow)){
				anim.SetBool ("moving", true);
				anim.SetInteger ("direction", -2);

				lastDirection = KeyCode.LeftArrow;
				this.gameObject.transform.position += Vector3.left* posessionSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.UpArrow)){
				anim.SetBool ("moving", true);
				anim.SetInteger ("direction", 1);

				lastDirection = KeyCode.UpArrow;
				this.gameObject.transform.position += Vector3.up * posessionSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.DownArrow)){
				anim.SetBool ("moving", true);
				anim.SetInteger ("direction", -1);

				lastDirection = KeyCode.DownArrow;
				this.gameObject.transform.position += Vector3.down * posessionSpeed * Time.deltaTime;
			}
			gameObject.GetComponent<UseWeapon>().lastDirection = lastDirection;





			if (timer > 150) {
				timer = 0;
				posessed = false;

				anim.SetTrigger ("unposessed");
				anim.SetBool ("posessed", false);

				jinnScript.posessing = false;
				jinn.SetActive (true);
				Vector3 rightOf = new Vector3 (1.2f, 0f);
				jinn.transform.position = this.transform.position + rightOf;
				jinn.transform.rotation = this.transform.rotation;
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (collisionInfo.gameObject.CompareTag("weapon")) {
//			this.GetComponent<SpriteRenderer> ().color = Color.red;

			hits += 1;
			if (hits >= TO_KILL) {
				//ded
				this.gameObject.SetActive (false);
				summonerProps.changeMana (3);
				summonerProps.changeHealth (5);
			}
		} else if (collisionInfo.gameObject.CompareTag("jinn")) {
			summonerProps.changeMana (-1);
			anim.SetBool ("posessed", true);

			hits += 1;

			posessed = true;

			this.GetComponent<SpriteRenderer> ().color = Color.gray;
			jinn = collisionInfo.gameObject;
			jinnScript = jinn.GetComponent<JinnScript> ();
			jinnScript.posessing = true;


			jinn.SetActive (false);
			timer = 0;


		}
	}
}
