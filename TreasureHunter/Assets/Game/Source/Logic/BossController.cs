using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	public bool isSwitch1On;
	public bool isSwitch2On;
	public bool isSwitch3On;
	public bool isSwitch4On;
	public Slider healthBar;
	public GameObject skillActive;
	public GameObject chest;

	float timeForNewPoint = 3;
	float speed;
	Vector2 newTargetPoint;
	bool isInCoroutine;

	Animator animator;
	private static BossController _instance;
	public static BossController Instance {
		get { 
			return _instance;
		}
	}

	void Awake() {
		if (_instance != null) {
			Destroy (this.gameObject);
		}
		_instance = this;
	}
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isInCoroutine) {
			StartCoroutine (WaitMove ());
		}
	}

	public void HealthDown(){
		healthBar.value--;
		animator.SetBool ("isHurt", true);
		if (healthBar.value == 0) {
			BossDead();
		}
	}

	void BossDead(){
		animator.SetBool ("isDead", true);
		chest.SetActive (true);
	}

	Vector2 NewPointCreate() {
		float x = Random.Range (-7, 7);
		float y = Random.Range (2, 5); 
		return new Vector2 (x, y);
	}

	IEnumerator WaitMove (){
		animator.SetBool ("isHurt", false);
		isInCoroutine = true;
		yield return new WaitForSeconds (timeForNewPoint);
		Move (gameObject.transform.localPosition, NewPointCreate ());
		animator.SetBool ("isAttack", true);
		LightningUse (true);
		yield return new WaitForSeconds (3);
		LightningUse (false);
		animator.SetBool ("isAttack", false);
		isInCoroutine = false;
	}

	void Move(Vector2 fromPos, Vector2 toPos){
		gameObject.GetComponent<Rigidbody2D> ().MovePosition (Vector2.Lerp(fromPos, toPos, 5));
	}

	void LightningUse(bool isUse){
		skillActive.SetActive (isUse);
	}
}
