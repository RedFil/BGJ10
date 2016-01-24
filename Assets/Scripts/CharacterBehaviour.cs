using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CharacterBehaviour : MonoBehaviour {
	private float moveDirection = 0f;
	private float facingDirection = 1.0f;

//	[Tooltip("The move speed.")]
	public float moveSpeed = 0.1f;

	[HideInInspector]
	private bool action1;
	public float attackStrength = 100.0f;
	public GameObject attackSprite;

	public float attackCooldown = 0.5f;
	private float attackTime = 0;

	public CharacterAttackChecker attackChecker;

	// Use this for initialization
	void Start () {
		if (attackChecker == null) {
			try {
				attackChecker = GetComponent<CharacterAttackChecker> ();
			} catch (Exception exc) {
				Debug.LogError ("No CharacterAttackChecker script found in the gameObject: " + exc);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move (moveDirection);
		Attack (action1);
	}

	public void SetMovingDirection (float direction) {
		moveDirection = direction;
	}

	public void SetAction1Trigger (bool action1Trigger) {
		action1 = action1Trigger;
	}

	private void Move (float direction) {
		if (direction != 0) {

			// Flip the gameObject to face its walking direction (if needed)
			if (direction > 0 && transform.rotation.eulerAngles.y != 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);

				// Update the last facing direction
				facingDirection = 1.0f;
			} else if (direction < 0 && transform.rotation.eulerAngles.y != 180) {
				transform.rotation = Quaternion.Euler (0, 180, 0);

				// Update the last facing direction
				facingDirection = -1.0f;
			}

			// Move the gameObject to the facing direction
			transform.Translate (moveSpeed, 0, 0);
		}
	}

	private void Attack (bool attack) {
		if (attack && attackTime + attackCooldown < Time.time) {
			// Sets the attack's cooldown.
			attackTime = Time.time;

			// Toggle the attack's sprite to visible
			try {
				attackSprite.GetComponent<AttackSpriteBehaviour> ().ShowAttack ();
			} catch (Exception exc) {
				Debug.LogError ("No AttackSprite object was detected in " + gameObject.name + ": " + exc);
			}

			// Raycast and get all GameObjects with colliders in the attack line
			List<GameObject> hits = attackChecker.CheckAttackCollision (facingDirection);

			// Filter the Game Objects in the attack line, getting only those that can be destroyed
			List<ObjectDestructible> objs = GetDestructibleObjectsOnAttackLine (hits);

			// Inflict damage to all destructible objects
			foreach (ObjectDestructible obj in objs) {
				obj.takeDamage (attackStrength);
			}
		}
	}

	private List<ObjectDestructible> GetDestructibleObjectsOnAttackLine (List<GameObject> colliders) {
		List<ObjectDestructible> objs = new List<ObjectDestructible> ();

		// Filter all given objects, selecting only those with the ObjectDestructible script on it
		foreach (GameObject hit in colliders) {
			ObjectDestructible obj = hit.GetComponent<ObjectDestructible> ();

			if (obj != null) {
				objs.Add (obj);
			}
		}

		return objs;
	}
}
