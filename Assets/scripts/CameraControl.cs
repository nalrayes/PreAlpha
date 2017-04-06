using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
//	Camera cam = this.gameObject.GetComponent<Camera>();	
	GameObject summoner;
	public Transform target;
	public float moveSpeed = 8f;

	// Use this for initialization
	void Start () {
		summoner = GameObject.FindGameObjectWithTag("summoner");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 targetPosition = Vector2.Lerp(transform.position, target.position, moveSpeed*Time.deltaTime);
		transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
	}
}
