using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	private GameObject followObject;

	private Vector3 oldPos;
	private Vector3 newPos;
	[Tooltip("The transition speed when moving to another fixed point.")]
	public float screenTransitionSpeed = 0.5f;
	private float startMoveTime = 0;

	// Use this for initialization
	void Start () {
		oldPos = transform.position;
		newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (followObject != null) {
			Vector3 toPos = followObject.transform.position;
			Vector3 myPos = transform.position;
			transform.position = new Vector3 (toPos.x, myPos.y, myPos.z);
		} else if (transform.position != newPos) {
			transform.position = Vector3.Lerp (oldPos, newPos, (Time.time - startMoveTime) / 1.0f);
		}
	}

	public void MoveToPosition (Vector3 newPosition) {
		if (newPos != newPosition) {
			startMoveTime = Time.time;
			oldPos = transform.position;
			newPos = newPosition;
		}
	}

	public void FollowObject (GameObject obj) {
		followObject = obj;
	}

	public void StopFollowing () {
		followObject = null;
	}
}
