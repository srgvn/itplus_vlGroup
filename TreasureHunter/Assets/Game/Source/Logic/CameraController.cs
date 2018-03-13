using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(transform.position.x - player.transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(offset.x + player.transform.position.x, transform.position.y, transform.position.z);
	}
}
