using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{

	public bool isSwitch1On;
	public bool isSwitch2On;
	public bool isSwitch3On;
	public bool isSwitch4On;
	public Slider healthBar;
	public GameObject[] lightningArr;

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

	void Awake ()
	{
		if (_instance != null) {
			Destroy (this.gameObject);
		}
		_instance = this;
	}
	// Use this for initialization
	void Start ()
	{
		animator = gameObject.GetComponent<Animator> ();
		StartCoroutine (WaitMove ());
	}

	public void HealthDown ()
	{
		healthBar.value--;
		animator.SetBool ("isHurt", true);
		if (healthBar.value == 0) {
			BossDead ();
		}
	}

	void BossDead ()
	{
		animator.SetBool ("isDead", true);
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		LightningUse (false);
		chest.SetActive (true);
		MainCharacterController.MainCtrl.bossKilled = 1;
		MainCharacterController.MainCtrl.totalGold += 3000;
	}

	Vector2 NewPointCreate ()
	{
		float x = Random.Range (-7, 7);
		float y = Random.Range (2, 5); 
		return new Vector2 (x, y);
	}

	IEnumerator WaitMove ()
	{
		animator.SetBool ("isHurt", false);
		yield return new WaitForSeconds (timeForNewPoint);
		Move (gameObject.transform.localPosition, NewPointCreate ());
		animator.SetBool ("isAttack", true);
		LightningUse (true);
		yield return new WaitForSeconds (3);
		LightningUse (false);
		animator.SetBool ("isAttack", false);
		StartCoroutine (WaitMove ());
	}

	void Move (Vector2 fromPos, Vector2 toPos)
	{
		gameObject.GetComponent<Rigidbody2D> ().MovePosition (Vector2.Lerp (fromPos, toPos, 5));
	}

	void LightningUse (bool isUse)
	{
		int random = Random.Range (0, 3);
		for (int i = 0; i <= 2; i++) {
			if (i == random) {
				lightningArr [i].SetActive (true);
			} else {
				lightningArr [i].SetActive (false);
			}
		}
		SoundController.instance.PlayLightningSound ();
	}
}
