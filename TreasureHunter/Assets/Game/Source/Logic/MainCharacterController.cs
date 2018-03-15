﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour {

	public int skinActive;
	public bool isJumping = false;
	private static MainCharacterController _mainCtrl;
	public static MainCharacterController MainCtrl {
		get { 
			return _mainCtrl;
		}
	}

	void Awake() {
		if (_mainCtrl != null) {
			Destroy (this.gameObject);
		}
		_mainCtrl = this;
		LoadAnimation (skinActive);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadAnimation(int skinActive) {
//		if (skinActive == 1) {
//			this.gameObject.transform.GetChild(0).GetComponent<Animator>().
//		}
	}

//	void OnCollisionEnter2D(Collision2D col){
//		string tagName = col.gameObject.tag;
//		if (tagName.Equals ("Ground")) {
//			isJumping = false;
//		}
//		Debug.Log (col.gameObject.name + " " + tagName + " " + isJumping);
//	}
//
	void OnCollisionExit2D(Collision2D col) {
		string tagName = col.gameObject.tag;
		if (tagName.Equals("Ground")){
			isJumping = true;
		}
		Debug.Log (col.gameObject.name + " " + tagName + " " + isJumping);
	}

	void OnCollisionStay2D(Collision2D col){
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		}
		//Debug.Log (col.gameObject.name + " " + tagName + " " + isJumping);
	}
}
