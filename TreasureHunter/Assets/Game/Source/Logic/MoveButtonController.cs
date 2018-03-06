using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtonController : MonoBehaviour {
	public Vector2 runningSpeed;
	public int buttonClicked;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = MainCharacterController.MainCtrl.gameObject.GetComponent<Animator> ();
		runningSpeed = new Vector2 (5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", false);
			animator.SetBool ("isRunBwd", true);
			MapController.MapCtrl.gameObject.transform.Translate (runningSpeed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunBwd", false);
			animator.SetBool ("isJumpBwd", false);
			animator.SetBool ("isRunFwd", true);
			MapController.MapCtrl.gameObject.transform.Translate (-runningSpeed * Time.deltaTime);
		} else {
			animator.SetBool ("isIdle", true);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", false);
			animator.SetBool ("isRunBwd", false);
		}
	}

	public void OnMouseOver () {
		if (buttonClicked == 1) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJumpFwd", false);
			animator.SetBool ("isRunBwd", true);
			MapController.MapCtrl.gameObject.transform.Translate(runningSpeed * Time.deltaTime);
		} else if (buttonClicked == 2){
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunBwd", false);
			animator.SetBool ("isJumpBwd", false);
			animator.SetBool ("isRunFwd", true);
			MapController.MapCtrl.gameObject.transform.Translate(-runningSpeed * Time.deltaTime);
		}
	}

	public void OnMouseExit (){
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
		animator.SetBool ("isJumpFwd", false);
		animator.SetBool ("isRunBwd", false);
	}

}
