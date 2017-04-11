using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFeetScript2 : MonoBehaviour {
	private Animator anim;

	public bool walking = false;
	public int direction = 0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		walking = GetComponentInParent<EnemyAI> ().moving;
		direction = GetComponentInParent<EnemyAI> ().direction;
		if (GetComponentInParent<EnemyAI> ().moving) {
//			Debug.Log (direction);
//			Debug.Log (walking);
			anim.SetBool ("moving", walking);
			anim.SetInteger ("direction", direction);
		} else {
			anim.SetBool ("moving", false);
		}
	}
}
