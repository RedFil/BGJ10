using UnityEngine;
using System;
using System.Collections;

public class TransitionBlock : MonoBehaviour {
	public Transform moveCameraToPosition;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "MainCharacter") {
			CameraBehaviour camera = GameObject.Find ("MainCamera").GetComponent<CameraBehaviour> ();
			if (camera == null) {
				Debug.LogError ("No 'MainCamera' was found in the scene to make a transition command.");
				return;
			}

			if (moveCameraToPosition != null) {
				camera.StopFollowing ();
				camera.MoveToPosition (moveCameraToPosition.position);
			} else {
				Debug.Log ("No point setted to move the Camera, therefor it will follow the MainCharacter.");

				GameObject mainChar = GameObject.Find ("MainCharacter");

				if (mainChar != null) {
					camera.FollowObject (mainChar);
				} else {
					Debug.LogError ("No 'MainCharacter' was found in the scene to do the follow command.");
				}
			}
		}
	}
}
