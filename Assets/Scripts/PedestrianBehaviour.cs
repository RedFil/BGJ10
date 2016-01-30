using UnityEngine;
using System;
using System.Collections;

public class PedestrianBehaviour : MonoBehaviour {
	[Tooltip("The object which the Pedesrian will run from.")]
	public GameObject runningFrom;
	private bool running = false;
	private float startRunningTime = 0;
	[Tooltip("How long the Pedestrian will run.")]
	public float maxTimeRunning = 2.0f;
	[Tooltip("The Pedestrian's run speed.")]
	public float moveSpeed = 0.25f;

	// Use this for initialization
	void Start () {
		// If no 'runningFrom' object was setted, look for a 'MainCharacter'
		if (runningFrom == null) {
			runningFrom = GameObject.Find ("MainCharacter");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			// Check the Pedestrian's timer
			if (startRunningTime + maxTimeRunning < Time.time) {
				running = false;
				return;
			}

			// Move the pedestrian
			try {
				int direction = 1;

				if (runningFrom.transform.position.x > gameObject.transform.position.x) {
					direction = -1;
				}

				transform.Translate (moveSpeed * direction, 0, 0);
			} catch (Exception exc) {
				Debug.LogError ("No 'MainCharacter' was found the the Scene: " + exc);
			}
		}
	}

	void OnTriggerEnter2D (Collider other) {
		if (other.gameObject.name == "MainCharacter") {
			startRunningTime = Time.time;
			running = true;
		}
	}
}
