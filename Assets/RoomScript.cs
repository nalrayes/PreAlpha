using System.Collections;
using System.Collections.Generic;
using UnityEngine;	

public class RoomScript : MonoBehaviour {
	const float maxX = 10f, maxY = 4.5f, minX = 10f, minY = 4.5f;

	MoveScript summoner; 
	// Use this for initialization
	void Start () {
		summoner = GameObject.FindGameObjectWithTag ("summoner").GetComponent<MoveScript> ();
	}

	// Update is called once per frame
	void Update () {
		Transform currentTarget = Camera.main.GetComponent<CameraControl> ().target;
		bool summonerIsHere = summoner.transform.position.y < transform.position.y + maxY && summoner.transform.position.y > transform.position.y - minY
		                      && summoner.transform.position.x < transform.position.x + maxX && summoner.transform.position.x > transform.position.x - minX;
		if (summonerIsHere) {
			Debug.Log (transform);
			Camera.main.GetComponent<CameraControl> ().target = transform;
		}
	}
}
