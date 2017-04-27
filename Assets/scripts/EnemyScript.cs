using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public bool posessed = false;
	float timer;
	float posessionSpeed;

	public int POSESSION_LIMIT = 1000;

	GameObject jinn;
	JinnScript jinnScript;

	int TO_KILL = 2;
	public int hits;

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
	int direction = 0;
	bool moving = false;
	PropertyScript summonerProps;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		timer = 0;
//		attackTimer = 0;
		posessionSpeed = 2.0f;

		hits = 0;

		weaponScript= gameObject.GetComponent<UseWeapon> ();
		weaponUp = weaponScript.weaponUp;
		weaponRight = weaponScript.weaponRight;
		weaponLeft = weaponScript.weaponLeft;
		weaponDown = weaponScript.weaponDown;

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
		if (hits >= TO_KILL) {
			//ded
			this.gameObject.SetActive (false);
			summonerProps.changeMana (3);
			summonerProps.changeHealth (5);
		}
//		Debug.Log (weaponUp);
//		Debug.Log (weaponDown);
//		Debug.Log (weaponLeft);
//		Debug.Log (weaponRight);
		if (posessed) {
			timer++;
//			attackTimer++;
			if (Input.GetKey (KeyCode.RightArrow)) {
				direction = 2;
				moving = true;


				lastDirection = KeyCode.RightArrow;
				this.transform.position += Vector3.right * posessionSpeed * Time.deltaTime;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				direction = -2;
				moving = true;

				lastDirection = KeyCode.LeftArrow;
				this.gameObject.transform.position += Vector3.left * posessionSpeed * Time.deltaTime;
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				direction = 1;
				moving = true;

				lastDirection = KeyCode.UpArrow;
				this.gameObject.transform.position += Vector3.up * posessionSpeed * Time.deltaTime;
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				direction = -1;
				moving = true;

				lastDirection = KeyCode.DownArrow;
				this.gameObject.transform.position += Vector3.down * posessionSpeed * Time.deltaTime;
			} else {
				moving = false;
			}
			anim.SetBool ("moving", moving);
			anim.SetInteger ("direction", direction);

			GetComponentInChildren<EnemyAI> ().moving = moving;
			GetComponentInChildren<EnemyAI> ().direction = direction;
			gameObject.GetComponent<UseWeapon>().lastDirection = lastDirection;





			if (timer > POSESSION_LIMIT || Input.GetKeyDown(KeyCode.Space)) {
				weaponUp.tag = "enemy weapon";
				weaponRight.tag = "enemy weapon";
				weaponLeft.tag = "enemy weapon";
				weaponDown.tag = "enemy weapon";

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
			anim.SetTrigger ("start posess");

			weaponUp.tag = "weapon";
			weaponRight.tag = "weapon";
			weaponLeft.tag = "weapon";
			weaponDown.tag = "weapon";

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
