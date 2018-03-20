using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour {
	
	bool isBottomLimit;
	bool isTopLimit = true;
	Vector2 fallingSpeed;

	public bool isAuto;
	public bool isOdd;
	public float topLimit;
	public float bottomLimit;

	// Use this for initialization
	void Start () {
		fallingSpeed = new Vector2 (0, (float)0.2);
	}
	
	// Update is called once per frame
	void Update () {
		checkLimit ();
		if (isAuto) {
			if (isTopLimit) {
				this.gameObject.transform.Translate (-fallingSpeed * Time.deltaTime);
			} else if (isBottomLimit) {
				this.gameObject.transform.Translate (fallingSpeed * Time.deltaTime);
			}
		}
	}

	void checkLimit() {
		Vector2 pos = this.gameObject.transform.localPosition;
		if (this.gameObject.transform.localPosition.y < bottomLimit) {
			isBottomLimit = true;
			isTopLimit = false;
		} else if (this.gameObject.transform.localPosition.y > topLimit) {
			isBottomLimit = false;
			isTopLimit = true;
		}
	}
}
