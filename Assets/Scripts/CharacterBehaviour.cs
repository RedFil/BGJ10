using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CharacterBehaviour : MonoBehaviour {
	[HideInInspector]
	public float moveDirection = 0f;

//	[Tooltip("The move speed.")]
	public float moveSpeed = 0.1f;

	[HideInInspector]
	public bool action1;
	public float attackStrength = 100.0f;

	public CharacterAttackChecker attackChecker;

	// Use this for initialization
	void Start () {
		if (attackChecker == null) {
			try {
				attackChecker = GetComponent<CharacterAttackChecker> ();
			} catch (Exception exc) {
				Debug.Log ("No CharacterAttackChecker script found in the gameObject: " + exc);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move (moveDirection);
		Attack (action1);
	}

	private void Move (float direction) {
		if (direction != 0) {
			transform.Translate (moveSpeed * moveDirection, 0, 0);
		}
	}

	private void Attack (bool attack) {
		if (attack) {
			List<GameObject> hits = attackChecker.CheckAttackCollision ();

			List<ObjectDestructible> objs = GetDestructibleObjectsOnAttackLine (hits);

			foreach (ObjectDestructible obj in objs) {
				obj.takeDamage (attackStrength);
			}
		}
	}

	private List<ObjectDestructible> GetDestructibleObjectsOnAttackLine (List<GameObject> colliders) {
		List<ObjectDestructible> objs = new List<ObjectDestructible> ();

		foreach (GameObject hit in colliders) {
			ObjectDestructible obj = hit.GetComponent<ObjectDestructible> ();

			if (obj != null) {
				objs.Add (obj);
			}
		}

		return objs;
	}
}
