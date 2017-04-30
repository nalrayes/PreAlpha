using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.CompareTag("summoner")) {
			SceneManager.LoadScene (3);
		}
	}
}
