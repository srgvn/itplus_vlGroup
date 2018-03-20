using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour {

	bool isDead;
	Animator animator;
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
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadAnimation(int skinActive) {
//		if (skinActive == 1) {
//			this.gameObject.transform.GetChild(0).GetComponent<Animator>().
//		}
	}

	void OnCollisionEnter2D(Collision2D col){
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		} else if (tagName.Equals ("BushTrap") || tagName.Equals ("SpikeTrap") || tagName.Equals ("RockTrapDead") || tagName.Equals("Monster")) {
			isDead = true;
			animator.SetBool ("isDead", true);
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJump", false);
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		string tagName = col.gameObject.tag;
		if (tagName.Equals("Ground")){
			isJumping = true;
		}
	}

	void OnCollisionStay2D(Collision2D col){
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("RockTrapDead") || tagName.Equals("Piranha")) {
			isDead = true;
			animator.SetBool ("isDead", true);
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJump", false);
		}
	}
}
