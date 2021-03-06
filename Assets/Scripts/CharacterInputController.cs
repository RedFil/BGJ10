﻿using UnityEngine;
using System;
using System.Collections;

public class CharacterInputController : MonoBehaviour {
	public CharacterBehaviour charBehaviour;

	public float hAxisInput { get; private set; }
	public float vAxisInput { get; private set; }
	public bool action1Input { get; private set; }

	// Use this for initialization
	void Start () {
		if (charBehaviour == null) {
			try {
				charBehaviour = GetComponent<CharacterBehaviour> ();
			} catch (Exception exc) {
				Debug.LogError ("No CharacterBehaviour script found in the " + gameObject.name + " object: " + exc);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (charBehaviour != null) {
			charBehaviour.SetMovingDirection (Input.GetAxisRaw ("Horizontal"));
			charBehaviour.SetAction1Trigger (Input.GetButton ("Fire1"));
		} else {
			Debug.LogError ("No CharacterBehaviour setted in the " + gameObject.name + " object.");
		}
	}
}
