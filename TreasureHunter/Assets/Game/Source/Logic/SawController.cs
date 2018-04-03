using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("UnderWater")) {
			Destroy (col.gameObject);
		}
	}
}
