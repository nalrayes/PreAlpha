using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpenDoorScript : MonoBehaviour {

	bool open = false;
	Vector3 endpos;
	float speed = .5f;
	
	// Update is called once per frame
	void Update () {
		if (open) {
			transform.position = Vector3.Lerp (transform.position, endpos, speed * Time.deltaTime); 
		}
	}

	public void openDoor(float posx, float posy, float posz) {
		endpos = new Vector3 (posx, posy, posz);
		open = true;
	}
}
