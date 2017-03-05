using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackAndForth : MonoBehaviour {
	public Vector3 direction;
	Vector3 originalPos;

	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		direction = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.position.y == -1 * originalPos.y);
		if (transform.position.y == -1 * originalPos.y) {
			direction = -1 * direction;
		}
		gameObject.transform.position += 5f* direction * Time.deltaTime;

	}
}
