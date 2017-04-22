using System.Collections;
using System.Collections.Generic;
using UnityEngine;	

public class RoomScript : MonoBehaviour {
	const float maxX = 5f, maxY = 2.5f, minX = 5f, minY = 2.5f;

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
//			Debug.Log (transform);
//			Debug.Log("ayyyyyy");
			Camera.main.GetComponent<CameraControl> ().target = transform;
		}
	}
}
