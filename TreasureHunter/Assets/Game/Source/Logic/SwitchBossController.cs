using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBossController : MonoBehaviour
{

	public Sprite switchOn;
	public Sprite switchOff;
	public GameObject disappearObj;
	bool isOn;

	void OnCollisionEnter2D (Collision2D col)
	{
		string name = gameObject.name;
		if (col.gameObject.tag.Equals ("Player")) {
			if (!isOn) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn;
				isOn = true;
				StartCoroutine (SwitchOnAction ());
			}
		}
		if (name.Equals ("Switch1")) {
			BossController.Instance.isSwitch1On = true;
		} else if (name.Equals ("Switch2")) {
			BossController.Instance.isSwitch2On = true;
		} else if (name.Equals ("Switch3")) {
			BossController.Instance.isSwitch3On = true;
		} else if (name.Equals ("Switch4")) {
			BossController.Instance.isSwitch4On = true;
			if (BossController.Instance.isSwitch1On && BossController.Instance.isSwitch2On && BossController.Instance.isSwitch3On) {
				resetSwitch ();
				BossController.Instance.HealthDown ();
			}
		}

	}

	IEnumerator SwitchOnAction ()
	{
		yield return new WaitForSeconds ((float)0.5);
		disappearObj.SetActive (false);
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<Collider2D> ().isTrigger = true;
		yield return new WaitForSeconds (1);
		disappearObj.SetActive (true);
		isOn = false;
		if (gameObject.name.Equals ("Switch4")) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = switchOff;
			gameObject.GetComponent<Collider2D> ().isTrigger = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void resetSwitch ()
	{
		BossController.Instance.isSwitch1On = false;
		BossController.Instance.isSwitch2On = false;
		BossController.Instance.isSwitch3On = false;
		foreach (GameObject swt in GameObject.FindGameObjectsWithTag("SwitchBoss")) {
			swt.GetComponent<SpriteRenderer> ().sprite = switchOff;
			swt.GetComponent<Collider2D> ().isTrigger = false;
			swt.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
