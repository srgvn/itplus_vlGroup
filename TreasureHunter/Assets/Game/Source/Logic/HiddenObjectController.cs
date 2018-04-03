using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjectController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
