using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrapController : MonoBehaviour {

	bool isFalling;
	Vector2 fallingSpeed;
	// Use this for initialization
	void Start () {
		fallingSpeed = new Vector2 (0, 3);
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling) {
			//this.gameObject.transform.parent.gameObject.transform.Translate (-fallingSpeed * Time.deltaTime); 
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Equals ("Player")) {
			isFalling = true;
			this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
	}
}
