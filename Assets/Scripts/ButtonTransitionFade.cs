using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ButtonTransitionFade : MonoBehaviour {
	public float fadeSpeed = 1.5f;

	private Image image;

	// Use this for initialization
	void Start () {
		// Create the fade in/out rectangle with the size of the user's screen
		RectTransform rectTransform = GetComponent<RectTransform> ();
		try {
			rectTransform.sizeDelta = new Vector2 (Screen.width, Screen.height);
		} catch (Exception exc) {
			Debug.LogError ("No RectTransform was found in the object " + gameObject.name +  ": " + exc);
		}

		// Set the rectangle to start invisible/clear
		image = GetComponent<Image> ();
		try {
			image.color = Color.clear;
		} catch (Exception exc) {
			Debug.LogError ("No Image was found in the object " + gameObject.name + ": " + exc);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
