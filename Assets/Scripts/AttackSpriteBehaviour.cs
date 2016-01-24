using UnityEngine;
using System;
using System.Collections;

public class AttackSpriteBehaviour : MonoBehaviour {
	[Tooltip("How long the attack's sprite will be shown.")]
	public float screenTime = 0.2f;
	private float shownTime = 0;

	public SpriteRenderer sprRend;

	// Use this for initialization
	void Start () {
		if (sprRend == null) {
			sprRend = GetComponent<SpriteRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		try {
			if (sprRend.enabled && shownTime + screenTime < Time.time) {
				sprRend.enabled = false;
			}
		} catch (Exception exc) {
			Debug.LogError ("No SpriteRenderer was found in " + gameObject.name + ": " + exc);
		}
	}

	public void ShowAttack () {
		sprRend.enabled = true;
		shownTime = Time.time;
	}
}
