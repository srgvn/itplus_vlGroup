using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

	public Sprite switchOn;
	public Sprite switchOff;
	public GameObject disappearObj;
	bool isOn;
	// Use this for initialization
	void Start () {
		isOn = false;
		DisableChild (gameObject, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name.Equals ("Player")) {
			if (!isOn) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn;
				isOn = true;
				StartCoroutine (SwitchOnAction());
			}
		}
	}

	IEnumerator SwitchOnAction(){
		DisableChild (gameObject, true);
		yield return new WaitForSeconds ((float)0.5);
		disappearObj.SetActive (false);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (1);
		disappearObj.SetActive (true);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOff;
		isOn = false;
		DisableChild (gameObject, false);
	}

	void DisableChild(GameObject obj, bool isDisable) {
		for (int i = 0; i < obj.transform.childCount; i++) {
			foreach(SpriteRenderer sp in obj.transform.GetChild (i).GetComponentsInChildren<SpriteRenderer> ()) {
				sp.enabled = isDisable;
			}
		
			foreach(PolygonCollider2D pc in obj.transform.GetChild (i).GetComponentsInChildren<PolygonCollider2D> ()) {
				pc.enabled = isDisable;
			}
		}
	}
}
