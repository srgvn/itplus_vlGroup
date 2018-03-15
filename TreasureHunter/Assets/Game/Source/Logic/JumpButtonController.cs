using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonController : MonoBehaviour {
	public Vector2 jumpForce;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = MainCharacterController.MainCtrl.gameObject.GetComponent<Animator> ();
	}

	public void OnMouseDown () {
		Debug.Log ("bbb");
		if (!MainCharacterController.MainCtrl.isJumping) {
			Debug.Log ("ccc");
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJump", true);
			MainCharacterController.MainCtrl.gameObject.GetComponent<Rigidbody2D> ().AddForce (jumpForce);
		}
	}

	public void OnMouseUp (){
		Debug.Log ("aaa");
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
		animator.SetBool ("isJump", false);
	}
}
