﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Collider2D> ().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag.Equals ("UnderWater")) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 600));
			gameObject.GetComponent<Collider2D> ().isTrigger = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Equals ("ResetTriggerPoint")) {
			gameObject.GetComponent<Collider2D> ().isTrigger = false;
		}
	}
}