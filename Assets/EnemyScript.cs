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


	// Use this for initialization
	void Start () {
		timer = 0;
		posessionSpeed = 2.0f;

		hits = 0;
	}

	// Update is called once per frame
	void Update () {
		if (posessed) {
			timer++;
			if (Input.GetKey(KeyCode.RightArrow)){
				//lastDirection = KeyCode.RightArrow;
				this.transform.position += Vector3.right * posessionSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.LeftArrow)){
				//lastDirection = KeyCode.LeftArrow;
				this.gameObject.transform.position += Vector3.left* posessionSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.UpArrow)){
				//lastDirection = KeyCode.UpArrow;
				this.gameObject.transform.position += Vector3.up * posessionSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.DownArrow)){
				//lastDirection = KeyCode.DownArrow;
				this.gameObject.transform.position += Vector3.down * posessionSpeed * Time.deltaTime;
			}

			if (timer > 150) {
				timer = 0;
				posessed = false;
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
			this.GetComponent<SpriteRenderer> ().color = Color.red;

			hits += 1;
			if (hits >= TO_KILL) {
				//ded
				this.gameObject.SetActive (false);
			}
		} else if (collisionInfo.gameObject.CompareTag("jinn")) {
			GameObject.FindGameObjectWithTag("summoner").gameObject.GetComponent<PropertyScript> ().changeMana (-1);

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
