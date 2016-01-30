using UnityEngine;
using System.Collections;

public class MovingObjectBehaviour : MonoBehaviour {
	private int facingDirection = -1;

	[Tooltip("The object's movement speed.")]
	public float moveSpeed = 0.1f;
	[Tooltip("Whether or not the object will change its facing direction to the same direction it is moving to.")]
	public bool faceMovingDirection = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move (int direction) {
		transform.Translate (direction * moveSpeed, 0, 0);

		if (faceMovingDirection) {
			ChangeFacingDirection (direction);
		}
	}

	void ChangeFacingDirection (int direction) {
		// Flip the gameObject to face its walking direction (if needed)
		if (direction > 0 && transform.rotation.eulerAngles.y != 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else if (direction < 0 && transform.rotation.eulerAngles.y != 180) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}
	}
}
