using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackAndForth2 : MonoBehaviour {
	public Vector3 direction;
	Vector3 originalPos;

	public AudioClip switchingSound;

	bool posessed;
	GameObject jinn;

	float speed = 8f;

	int timer = 0;
	bool stopping = false;
	Color32 originalColor;

	Animator anim;

	bool initialDirectionIsDown;
	// Use this for initialization
	void Start () {
		enabled = false;
		anim = GetComponent<Animator> ();
		anim.SetBool ("not stopped", true);

		originalPos = transform.localPosition;
//		direction = Vector3.down;
		if (direction == Vector3.up) {
			initialDirectionIsDown = false;
		} else if (direction == Vector3.down) {
			initialDirectionIsDown = true;
		}
		jinn = GameObject.FindGameObjectWithTag ("jinn");
		originalColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (transform.localPosition.y< -1 * originalPos.y);
		if (!posessed && !stopping) {
			if (initialDirectionIsDown) {
				if (direction.y == -1) {
					if (transform.localPosition.y < -1 * originalPos.y) {
						direction = -1 * direction;
						SoundManager.instance.PlaySingle (switchingSound);
					}
				} else {
					if (transform.localPosition.y > originalPos.y) {
						direction = -1 * direction;
						SoundManager.instance.PlaySingle (switchingSound);
					}
				}
			} else if (!initialDirectionIsDown) {
				if (direction.y == 1) {
					if (transform.localPosition.y > -1 * originalPos.y) {
						direction = -1 * direction;
						SoundManager.instance.PlaySingle (switchingSound);
					}
				} else {
					if (transform.localPosition.y < originalPos.y) {
						direction = -1 * direction;
						SoundManager.instance.PlaySingle (switchingSound);
					}
				}
			}
			GetComponent<Rigidbody2D> ().MovePosition (transform.position + speed * direction * Time.deltaTime);
		} else {
			timer++;
			if (timer > 90) {
				gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
				posessed = false;
				timer = 0;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag ("jinn")) {
//			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (180, 180, 30, 255); 
			posessed = true;
			info.gameObject.SetActive (false);
		} else if (info.gameObject.CompareTag ("summoner")) {
			//take dmg
			info.gameObject.GetComponent<PropertyScript> ().changeHealth (-5);
//		} else if (info.gameObject.CompareTag ("stopped box")) {
//			stopping = true;
		} else {
			stopping = false;
		}
	}

	void OnBecameVisible() {
		enabled = true;
	}

	void OnBecameInvisible() {
		enabled = false;
	}
}
