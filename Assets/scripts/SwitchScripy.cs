using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScripy : MonoBehaviour {

	public GameObject door;
	public Color32 oldColor;
	Color32 originalColor;

	public bool posessed = false;

	public AudioClip openSound;
	public AudioClip closeSound;

	float timer;
	int ftimer;
	GameObject jinn;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ftimer = 0;
		originalColor = this.GetComponent<SpriteRenderer> ().color;
		door = GameObject.Find ("Door");
	}
	
	// Update is called once per frame
	void Update () {
		if (posessed) {
			timer++;
			ftimer++;
			if (Input.GetKey (KeyCode.Q)) {
				if (door.activeSelf) {
					SoundManager.instance.PlaySingle (closeSound);
					anim.SetBool ("on", true);
					door.SetActive (false);	
					oldColor = this.GetComponent<SpriteRenderer> ().color;
//					this.GetComponent<SpriteRenderer> ().color = new Color32 (67, 161, 99, 255);
				} else {
//					this.GetComponent<SpriteRenderer> ().color = new Color32(180, 180, 30, 255); 
					if (ftimer > 3) {
						door.SetActive (true);
						ftimer = 0;
					}
				}
			}
			if (timer > 150) {
				timer = 0;
				posessed = false;
				jinn.SetActive (true);
				Vector3 rightOf = new Vector3 (1.2f, 0f);
				jinn.transform.position = GameObject.FindGameObjectWithTag ("summoner").transform.position + rightOf;
				jinn.GetComponent<JinnScript> ().posessing = false;
				anim.SetBool ("on", false);
//				this.GetComponent<SpriteRenderer> ().color = originalColor;
			}
		}	
	}
		
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		Debug.Log (door.GetComponent<DoorScript>().closed);
		if (collisionInfo.gameObject.CompareTag ("jinn")) {
			jinn = collisionInfo.gameObject;
			jinn.SetActive (false);
			timer = 0;
			jinn.GetComponent<JinnScript> ().posessing = true;
			posessed = true;
//			this.GetComponent<SpriteRenderer>().color =  new Color32(180, 180, 30, 255);
		} else {
			if (door.GetComponent<DoorScript>().closed) {
				SoundManager.instance.PlaySingle (closeSound);
				door.GetComponent<DoorScript> ().opening = true;
				anim.SetBool ("on", true);
//				door.SetActive (false);	
				oldColor = this.GetComponent<SpriteRenderer> ().color;
//				this.GetComponent<SpriteRenderer> ().color = new Color32 (67, 161, 99, 255);	
			} else if (door.GetComponent<DoorScript>().opened) {
				SoundManager.instance.PlaySingle (openSound);
				door.GetComponent<DoorScript> ().closing = true;
//				this.GetComponent<SpriteRenderer> ().color = originalColor;
				door.SetActive (true);
				anim.SetBool ("on", false);
			}
		}
	}
}
