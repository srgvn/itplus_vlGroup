using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrapController : MonoBehaviour {
	bool isBottomLimit;
	bool isTopLimit = true;
	Vector2 fallingSpeed;
	public bool isOdd;
	// Use this for initialization
	void Start () {
		fallingSpeed = new Vector2 (0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		checkLimit ();
		if (isTopLimit) {
			this.gameObject.transform.Translate (-fallingSpeed * Time.deltaTime);
		} else if (isBottomLimit) {
			this.gameObject.transform.Translate (fallingSpeed * Time.deltaTime);
		}
	}

	void checkLimit() {
		Vector2 pos = this.gameObject.transform.localPosition;
		if (this.gameObject.transform.localPosition.y < -1.1) {
			isBottomLimit = true;
			isTopLimit = false;
		} else if (this.gameObject.transform.localPosition.y > 6.1) {
			isBottomLimit = false;
			isTopLimit = true;
		}
	}
}
