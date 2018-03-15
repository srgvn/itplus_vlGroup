using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtonController : MonoBehaviour {
	private Vector2 runningSpeed;
	public int buttonClicked;
	private GameObject mainCharacter;
	private Animator animator;
	private bool facingRight;

	// Use this for initialization
	void Start () {
		mainCharacter = MainCharacterController.MainCtrl.gameObject;
		animator = mainCharacter.GetComponent<Animator> ();
		runningSpeed = new Vector2 (2, 0);
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 scale = mainCharacter.transform.localScale;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			scale.x = (float)-0.5; 
			mainCharacter.transform.localScale = scale;
			mainCharacter.transform.Translate (-runningSpeed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			scale.x = (float)0.5;
			mainCharacter.transform.localScale = scale;
			mainCharacter.transform.Translate (runningSpeed * Time.deltaTime);
		} else {
			animator.SetBool ("isIdle", true);
			animator.SetBool ("isRunFwd", false);
		}
	}

	public void OnMouseOver () {
		Vector2 scale = mainCharacter.transform.localScale;
		if (buttonClicked == 1) {
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			scale.x = (float)-0.5; 
			mainCharacter.transform.localScale = scale;
			mainCharacter.transform.Translate (-runningSpeed * Time.deltaTime);
		} else if (buttonClicked == 2){
			animator.SetBool ("isRunFwd", true);
			animator.SetBool ("isIdle", false);
			scale.x = (float)0.5;
			mainCharacter.transform.localScale = scale;
			mainCharacter.transform.Translate (runningSpeed * Time.deltaTime);
		}
	}

	public void OnMouseExit (){
		animator.SetBool ("isIdle", true);
		animator.SetBool ("isRunFwd", false);
	}

}
