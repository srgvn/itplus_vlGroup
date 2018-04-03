using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private Vector2 runningSpeed;
	private Vector2 jumpForce;
	public int buttonClicked;
	private GameObject mainCharacter;
	private Animator animator;
	private bool facingRight;
	private bool isPointerDown;
	private float temp = 0;
	// Use this for initialization
	void Start ()
	{
		mainCharacter = GameController.Instance.player;
		animator = mainCharacter.GetComponent<Animator> ();
		runningSpeed = new Vector2 (2, 0);
		jumpForce = new Vector2 (0, 450);
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (isPointerDown && buttonClicked == 1) {
//			mainCharacter.transform.Translate (-runningSpeed * Time.deltaTime);
//		} else if (isPointerDown && buttonClicked == 2) {
//			mainCharacter.transform.Translate (runningSpeed * Time.deltaTime);
//		}
//
		if (Input.GetKey (KeyCode.LeftArrow)) {
			mainCharacter.transform.Translate (-runningSpeed * Time.deltaTime);
			SoundController.instance.PlayRunSound ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			mainCharacter.transform.Translate (runningSpeed * Time.deltaTime);
			SoundController.instance.PlayRunSound ();
		} else {
			SoundController.instance.runSound.Stop ();
		}
	}

	public void OnJumpBtnOnClick ()
	{
		float temp = 0;
		temp += Time.deltaTime;
		if (!MainCharacterController.MainCtrl.isJumping) {
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isRunFwd", false);
			animator.SetBool ("isJump", true);
			if (temp < 0.2) {
				MainCharacterController.MainCtrl.gameObject.GetComponent<Rigidbody2D> ().AddForce (jumpForce);
			} else {
				MainCharacterController.MainCtrl.gameObject.GetComponent<Rigidbody2D> ().AddForce (jumpForce * 2);
			}
			SoundController.instance.PlayJumpSound ();
		}
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		Vector2 scale = mainCharacter.transform.localScale;
		isPointerDown = true;
		if (buttonClicked == 1) {
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isJump", false);
			scale.x = (float)-0.3;
		} else if (buttonClicked == 2) {
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			animator.SetBool ("isJump", false);
			scale.x = (float)0.3;
		}
		SoundController.instance.PlayRunSound ();
		mainCharacter.transform.localScale = scale;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		isPointerDown = false;
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
		SoundController.instance.runSound.Stop ();
	}

}
