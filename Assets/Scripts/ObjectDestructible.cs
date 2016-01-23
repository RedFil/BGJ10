using UnityEngine;
using System;
using System.Collections;

public class ObjectDestructible : MonoBehaviour {
	private float healthPoints = 100.0f;

	private float initialHealthPoints;

	public GameObject destroyedObjectPrefab;

	// Use this for initialization
	void Start () {
		// Save the initial health points to use as maximum health points.
		initialHealthPoints = healthPoints;
	}
	
	// Update is called once per frame
	void Update () {
		if (healthPoints <= 0) {
			try {
				Instantiate (destroyedObjectPrefab, transform.position, transform.rotation);
			} catch (Exception exc) {
				Debug.Log ("No DestroyedObjectPrefab was setted for " + gameObject.name + " object: " + exc);
			}

			Destroy (gameObject);
		}
	}

	public float takeDamage (float amount) {
		if (amount >= 0) {
			// Verify the sum to make sure no glitch will be shown to the user.
			if (healthPoints - amount > 0) {
				healthPoints -= amount;
			} else {
				healthPoints = 0;
			}
		}

		return healthPoints;
	}

	public float healHealth (float amount) {
		if (amount >= 0) {
			// Verify the sum to make sure no glitch will be shown to the user.
			if (healthPoints + amount < initialHealthPoints) {
				healthPoints += amount;
			} else {
				healthPoints = initialHealthPoints;
			}
		}

		return healthPoints;
	}
}
