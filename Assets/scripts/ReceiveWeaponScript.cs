using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveWeaponScript : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag ("jinn")) {
//			info.gameObject.transform.Find ("Weapons").gameObject.SetActive (true);
			gameObject.SetActive (false);
			GameObject.Find ("AutoTurret").gameObject.GetComponent<AutoRangedAttack> ().itemGet = true;
			GameObject.Find ("AutoTurret").gameObject.GetComponent<Animator> ().SetTrigger ("stopped");

			GameObject newEnemy1 = Instantiate (enemyPrefab) as GameObject;
			newEnemy1.transform.position = new Vector3 (10, -1, 10); 

			GameObject newEnemy2 = Instantiate (enemyPrefab) as GameObject;
			newEnemy2.transform.position = new Vector3 (10, 1, 10);

			GameObject newEnemy3 = Instantiate (enemyPrefab) as GameObject;
			newEnemy3.transform.position = new Vector3 (9, 0, 10);

			Debug.Log (newEnemy1);
			Debug.Log (newEnemy1.transform.position);
			Debug.Log (newEnemy2);
			Debug.Log (newEnemy2.transform.position);
			Debug.Log (newEnemy3);
			Debug.Log (newEnemy3.transform.position);

			GameObject exitDoor = GameObject.Find ("exit door");
			exitDoor.GetComponent<PpenDoorScript> ().openDoor (0f, (float) exitDoor.transform.position.y, (float) exitDoor.transform.position.y);
			exitDoor.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
