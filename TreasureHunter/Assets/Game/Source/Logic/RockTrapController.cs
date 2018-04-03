using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrapController : MonoBehaviour
{

	bool isFalling;
	Vector2 fallingSpeed;
	// Use this for initialization
	void Start ()
	{
		fallingSpeed = new Vector2 (0, 3);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			isFalling = true;
			this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Ground")) {
			this.gameObject.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}
}
