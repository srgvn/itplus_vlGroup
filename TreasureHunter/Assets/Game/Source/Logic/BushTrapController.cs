using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushTrapController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name.Equals ("Player")) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
