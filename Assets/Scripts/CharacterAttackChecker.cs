using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAttackChecker : MonoBehaviour {
	public List<GameObject> objsOnAttackLine;
	public float attackDistance = 1.0f;

	// Use this for initialization
	void Start () {
		objsOnAttackLine = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<GameObject> CheckAttackCollision (float facingDirection) {
		RaycastHit2D[] hits = Physics2D.RaycastAll (transform.position, Vector2.right * facingDirection, attackDistance);

		Debug.DrawRay (transform.position, Vector3.right * attackDistance * facingDirection, Color.green);

		// Clear the objs in the attack line
		objsOnAttackLine.Clear ();

		// If there is objs in the attack line, add them to the list
		if (hits.Length > 0) {
			foreach (RaycastHit2D hit in hits) {
				objsOnAttackLine.Add (hit.collider.gameObject);
			}
		}

		return objsOnAttackLine;
	}
}
