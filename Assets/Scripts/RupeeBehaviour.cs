using UnityEngine;
using System.Collections;

public class RupeeBehaviour : MonoBehaviour {
	[Tooltip("The rupee's life span.")]
	public float lifeSpan = 1.0f;
	private float bornTime;

	// Use this for initialization
	void Start () {
		bornTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (bornTime + lifeSpan <= Time.time) {
			Destroy (gameObject);
		}
	}
}
