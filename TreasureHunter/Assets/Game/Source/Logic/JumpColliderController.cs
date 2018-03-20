using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpColliderController : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name.Equals ("Player")) {
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, 500));
		}
	}
}
