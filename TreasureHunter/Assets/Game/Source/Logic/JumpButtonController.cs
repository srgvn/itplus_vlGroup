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
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown () {
		if (animator.GetBool ("isIdle")) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", false);
			animator.SetBool ("isRunBwd", false);
			animator.SetBool ("isJumpBwd", false);
			animator.SetBool ("isJump", true);
		} else if (animator.GetBool ("isRunFwd")){
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", true);
			animator.SetBool ("isRunBwd", false);
			animator.SetBool ("isJumpBwd", false);
			animator.SetBool ("isJump", false);
		} else if(animator.GetBool ("isRunBwd")) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", false);
			animator.SetBool ("isRunBwd", false);
			animator.SetBool ("isJumpBwd", true);
			animator.SetBool ("isJump", false);
		}
		MainCharacterController.MainCtrl.gameObject.GetComponent<Rigidbody2D> ().AddForce (jumpForce);
		MainCharacterController.MainCtrl.isJumping = true;
	}

	public void OnMouseUp (){
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
		animator.SetBool ("isJumpFwd", false);
		animator.SetBool ("isRunBwd", false);
		animator.SetBool ("isJumpBwd", false);
		animator.SetBool ("isJump", false);
		MainCharacterController.MainCtrl.isJumping = false;
	}
}
