using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGroundController : MonoBehaviour
{

	bool isFalling;
	Vector2 fallingSpeed;
	// Use this for initialization
	void Start ()
	{
		fallingSpeed = new Vector2 (0, 2);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isFalling) {
			this.gameObject.transform.parent.gameObject.transform.Translate (-fallingSpeed * Time.deltaTime); 
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			isFalling = true;
		}
	}
}
