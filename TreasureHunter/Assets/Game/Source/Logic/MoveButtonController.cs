using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtonController : MonoBehaviour {
	public int buttonClicked;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = MainCharacterController.MainCtrl.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseOver () {
		if (buttonClicked == 1) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", false);
			animator.SetBool ("isRunBwd", true);
		} else if (buttonClicked == 2){
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunBwd", false);
			animator.SetBool ("isJumpBwd", false);
			animator.SetBool ("isRunFwd", true);
		}
	}

	public void OnMouseExit (){
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
		animator.SetBool ("isJumpFwd", false);
		animator.SetBool ("isRunBwd", false);
	}

}
