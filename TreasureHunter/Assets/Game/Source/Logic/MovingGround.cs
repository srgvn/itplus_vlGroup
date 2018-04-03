using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
	public GameObject leftLimit;
	public GameObject rightLimit;

	bool isLeftLimit;
	bool isRightLimit;
	private Vector2 moveSpeed;
	// Use this for initialization
	void Start ()
	{
		moveSpeed = new Vector2 (5, 0);
		isLeftLimit = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isLeftLimit) {
			gameObject.transform.Translate (moveSpeed * Time.deltaTime);
		} else if (isRightLimit) {
			gameObject.transform.Translate (-moveSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals (leftLimit.name)) {
			isLeftLimit = true;
			isRightLimit = false;
			Debug.Log ("l");
		} else if (col.gameObject.name.Equals (rightLimit.name)) {
			isRightLimit = true;
			isLeftLimit = false;
			Debug.Log ("r");
		}
	}
}
