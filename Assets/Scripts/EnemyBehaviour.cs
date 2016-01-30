using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MovingObjectBehaviour {
	public float moveSpeed = 0.1f;

	private GameObject target;
	[Tooltip("The strength of the enemy's attacks.")]
	public float attackStrength = 10.0f;
	private float attackCooldown = 1.0f;
	private float lastAttackTime = 0;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("MainCharacter");
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			int movingDirection = transform.position.x > target.transform.position.x ? 1 : -1;

			Move (movingDirection);
		} else {
			Debug.LogError ("No target was setted for this enemy '" + gameObject.name + "' object.");
		}
	}

	void AttackTarget () {
		if (lastAttackTime + attackCooldown < Time.time) {
			// Update the attack time for the attack's cooldown
			lastAttackTime = Time.time;

			// Get the target's ObjectDestructible script to inflict damage
			ObjectDestructible targetDest = target.GetComponent<ObjectDestructible> ();

			// Try to inflict damage
			try {
				targetDest.takeDamage (attackStrength);
			} catch (Exception exc) {
				Debug.LogError ("No ObjectDestructible found in the 'target' " + target.name + ": " + exc);
			}
		}
	}

	void OnTriggerStay2D (Collider other) {
		if (other.gameObject.name == "MainCharacter") {
			AttackTarget ();
		}
	}
}
