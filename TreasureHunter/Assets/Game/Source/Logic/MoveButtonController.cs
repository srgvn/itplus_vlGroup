using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private Vector2 runningSpeed;
	private Vector2 jumpForce;
	public int buttonClicked;
	private GameObject mainCharacter;
	private Animator animator;
	private bool facingRight;
	private bool isPointerDown;

	// Use this for initialization
	void Start () {
		mainCharacter = MainCharacterController.MainCtrl.gameObject;
		animator = mainCharacter.GetComponent<Animator> ();
		runningSpeed = new Vector2 (3, 0);
		jumpForce = new Vector2 (0, 400);
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPointerDown && buttonClicked == 1) {
			mainCharacter.transform.Translate (-runningSpeed * Time.deltaTime);
		} else if (isPointerDown && buttonClicked == 2) {
			mainCharacter.transform.Translate (runningSpeed * Time.deltaTime);
		}
	}

	public void OnJumpBtnOnClick() {
		if (!MainCharacterController.MainCtrl.isJumping) {
			Debug.Log ("ccc");
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJump", true);
			MainCharacterController.MainCtrl.gameObject.GetComponent<Rigidbody2D> ().AddForce (jumpForce);
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		Vector2 scale = mainCharacter.transform.localScale;
		isPointerDown = true;
		if (buttonClicked == 1) {
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			scale.x = (float)-0.3;
		} else if (buttonClicked == 2){
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			scale.x = (float)0.3;
		}
		mainCharacter.transform.localScale = scale;
	}

	public void OnPointerUp(PointerEventData eventData) {
		isPointerDown = false;
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
	}

}
