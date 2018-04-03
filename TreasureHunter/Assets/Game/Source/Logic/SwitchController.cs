using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

	public Sprite switchOn;
	public Sprite switchOff;
	public GameObject disappearObj;
	int trapType;
	bool isOn;
	// Use this for initialization
	void Start ()
	{
		isOn = false;
		DisableChild (gameObject, false);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (gameObject.name.Equals ("Switch1")) {
			trapType = 1;
		} else if (gameObject.name.Equals ("Switch2")) {
			trapType = 2;
		}
		if (col.gameObject.tag.Equals ("Player")) {
			if (!isOn) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn;
				isOn = true;
				StartCoroutine (SwitchOnAction ());
			}
		}
	}

	IEnumerator SwitchOnAction ()
	{
		DisableChild (gameObject, true);
		yield return new WaitForSeconds ((float)0.5);
		disappearObj.SetActive (false);
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<Collider2D> ().isTrigger = true;
		yield return new WaitForSeconds (1);
		if (trapType == 1) {
			DisableChild (gameObject, false);
		} else if (trapType == 2) {
			gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ().gravityScale = 1;
			yield return new WaitForSeconds (5);
		}
		gameObject.GetComponent<Collider2D> ().isTrigger = false;
		disappearObj.SetActive (true);
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOff;
		isOn = false;

	}

	void DisableChild (GameObject obj, bool isDisable)
	{
		for (int i = 0; i < obj.transform.childCount; i++) {
			foreach (SpriteRenderer sp in obj.transform.GetChild (i).GetComponentsInChildren<SpriteRenderer> ()) {
				sp.enabled = isDisable;
			}
			foreach (PolygonCollider2D pc in obj.transform.GetChild (i).GetComponentsInChildren<PolygonCollider2D> ()) {
				pc.enabled = isDisable;
			}
		}
	}
}
