using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollControler : MonoBehaviour {

	public GameObject leftLimit;
	public GameObject rightLimit;

	bool isLeftLimit;
	bool isRightLimit;
	Vector2 runningSpeed;
	// Use this for initialization
	void Start () {
		runningSpeed = new Vector2 (3, 0);
		isLeftLimit = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isLeftLimit) {
			gameObject.transform.Translate (runningSpeed * Time.deltaTime);
		} else if (isRightLimit) {
			gameObject.transform.Translate (-runningSpeed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		Vector2 scaleTemp = gameObject.transform.localScale;
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name.Equals (leftLimit.name)) {
			scaleTemp.x = (float)0.5;
			isLeftLimit = true;
			isRightLimit = false;
		} else if (col.gameObject.name.Equals (rightLimit.name)) {
			scaleTemp.x = (float)-0.5;
			isRightLimit = true;
			isLeftLimit = false;
		} else if (col.gameObject.tag.Equals ("SpikeTrap") || col.gameObject.tag.Equals ("RockTrapDead")) {
			StartCoroutine (TrollDie());
		}
		gameObject.transform.localScale = scaleTemp;
	}
		
	IEnumerator TrollDie() {
		Animator animator = gameObject.GetComponent<Animator> ();
		animator.SetBool ("isDead", true);
		yield return new WaitForSeconds (2);
		gameObject.SetActive (false);
	}
}
