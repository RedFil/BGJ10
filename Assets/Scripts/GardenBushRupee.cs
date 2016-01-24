using UnityEngine;
using System;
using System.Collections;

public class GardenBushRupee : MonoBehaviour {
	public GameObject rupeePrefab;

	// Use this for initialization
	void Start () {
		if (UnityEngine.Random.Range (1, 4) != 0) {
			GameObject mainChar = GameObject.Find ("MainCharacter");

			if (mainChar != null) {
				try {
					GameObject rupee = (GameObject)Instantiate (rupeePrefab, mainChar.transform.position, mainChar.transform.rotation);
					rupee.transform.Translate (Vector3.up * 0.2f);
				} catch (Exception exc) {
					Debug.LogError ("No Rupee Prefab setted to create when bushes are cutted: " + exc);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
