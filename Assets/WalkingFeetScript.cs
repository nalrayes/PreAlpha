using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingFeetScript : MonoBehaviour {
	private Animator anim;

	bool walking;
	int direction;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		walking = GetComponentInParent<MoveScript> ().walking;
		direction = GetComponentInParent<MoveScript> ().directionValue;
		if (GetComponentInParent<MoveScript> ().walking) {
			Debug.Log (direction);
			Debug.Log (walking);
			anim.SetBool ("moving", walking);
			anim.SetInteger ("direction", direction);
		} else {
			anim.SetBool ("moving", false);
		}
	}
}
