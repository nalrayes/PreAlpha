using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {
	public float maxX, maxY, minX, minY;
	public Transform roomUp, roomDown, roomLeft, roomRight;

	MoveScript summoner; 
	// Use this for initialization
	void Start () {
		summoner = GameObject.FindGameObjectWithTag ("summoner").GetComponent<MoveScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		Transform currentTarget = Camera.main.GetComponent<CameraControl> ().target;
		if (currentTarget != transform)
			return;
		Transform nextTarget = transform;
		Debug.Log (transform.position);
		if (summoner.transform.position.y > transform.position.y + maxY) {
			nextTarget = roomUp;
		}
		if (summoner.transform.position.y > transform.position.y - minY) {
			nextTarget = roomDown;
		}
		if (summoner.transform.position.x > transform.position.x + maxX) {
			nextTarget = roomLeft;
		}
		if (summoner.transform.position.x > transform.position.x - minX) {
			nextTarget = roomRight;
		}
		
		if (nextTarget != null) {
			CameraControl cameraFollow = Camera.main.GetComponent<CameraControl> ();
			cameraFollow.target = nextTarget;
		}
		
	}
}
