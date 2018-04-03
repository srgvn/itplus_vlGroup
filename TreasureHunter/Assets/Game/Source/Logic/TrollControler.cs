using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollControler : MonoBehaviour
{

	public GameObject leftLimit;
	public GameObject rightLimit;

	public GameObject key;

	bool isLeftLimit;
	bool isRightLimit;
	Vector2 runningSpeed;
	// Use this for initialization
	void Start ()
	{
		runningSpeed = new Vector2 (3, 0);
		isLeftLimit = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isLeftLimit) {
			gameObject.transform.Translate (runningSpeed * Time.deltaTime);
		} else if (isRightLimit) {
			gameObject.transform.Translate (-runningSpeed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Vector2 scaleTemp = gameObject.transform.localScale;
		if (col.gameObject.name.Equals (leftLimit.name)) {
			scaleTemp.x = (float)0.5;
			isLeftLimit = true;
			isRightLimit = false;
		} else if (col.gameObject.name.Equals (rightLimit.name)) {
			scaleTemp.x = (float)-0.5;
			isRightLimit = true;
			isLeftLimit = false;
		} else if (col.gameObject.tag.Equals ("SpikeTrap")) {
			StartCoroutine (TrollDie ());
		}
		gameObject.transform.localScale = scaleTemp;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("RockTrapDead")) {
			GameObject gobj = col.gameObject.transform.parent.gameObject;
			Destroy (gobj);
			StartCoroutine (TrollDie ());
		}
	}

	IEnumerator TrollDie ()
	{
		Animator animator = gameObject.GetComponent<Animator> ();
		animator.SetBool ("isDead", true);
		yield return new WaitForSeconds (2);
		gameObject.SetActive (false);
		key.SetActive (true);
		MainCharacterController.MainCtrl.currentGold += 500;
	}
}
