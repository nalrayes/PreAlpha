using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource sfxSource;

	public static SoundManager instance = null;

	public float lowPitchRange = 0.95f;
	public float hightPitchRange = 1.05f;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip clip) {
		Debug.Log ("in playsignel");
		sfxSource.clip = clip;
		sfxSource.Play ();

		Debug.Log (sfxSource.isPlaying);
		Debug.Log (sfxSource.isActiveAndEnabled);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
