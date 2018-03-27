using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour {

	int keyCollected;
	bool isDead;
	Animator animator;
	public int skinActive;
	public bool isJumping = false;
	private static MainCharacterController _mainCtrl;
	int totalGold;
	int currentGold;
	public static MainCharacterController MainCtrl {
		get { 
			return _mainCtrl;
		}
	}

	void Awake() {
		if (_mainCtrl != null) {
			Destroy (this.gameObject);
		}
		_mainCtrl = this;
		LoadAnimation (skinActive);
	}
	// Use this for initialization
	void Start () {
		loadResult ();
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadAnimation(int skinActive) {
//		if (skinActive == 1) {
//			this.gameObject.transform.GetChild(0).GetComponent<Animator>().
//		}
	}

	void OnCollisionEnter2D(Collision2D col){
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		} else if (tagName.Equals ("BushTrap") || tagName.Equals ("SpikeTrap") || tagName.Equals ("RockTrapDead") || tagName.Equals ("Monster") || tagName.Equals ("UnderWater")) {
			Die ();
		} else if (tagName.Equals ("Door")) {
			if (keyCollected != 5) {
				Die ();
			} else {
				SceneManager.LoadScene ("BossScene");
			}
		} else if (col.gameObject.name.Equals ("Chest")) {
			currentGold += 5000;
			EndGame (true);
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		string tagName = col.gameObject.tag;
		if (tagName.Equals("Ground")){
			isJumping = true;
		}
	}

	void OnCollisionStay2D(Collision2D col){
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("RockTrapDead") || tagName.Equals ("Piranha")) {
			Die ();
		} else if (col.name.Equals ("ActivePoint")) {
			col.gameObject.transform.parent.GetComponent<Rigidbody2D> ().gravityScale = (float)0.5;
		} else if (tagName.Equals ("Key")) {
			keyCollected++;
			currentGold += 500;
			Destroy (col.gameObject);
		} else if (tagName.Equals ("Lightning")) {
			Die ();
		}
	}

	void Die(){
		isDead = true;
		animator.SetBool ("isDead", true);
		animator.SetBool ("isIdle", false);
		animator.SetBool ("isRunFwd", false);
		animator.SetBool ("isJump", false);
		EndGame (false);
	}

	void EndGame(bool isWin){
		//Time.timeScale = 0;
		Debug.Log("EndGame");
		submitResult ();
	}

	void loadResult() {
		if (PlayerPrefs.HasKey ("totalGold")) {
			totalGold = PlayerPrefs.GetInt ("totalGold");
		}
	}

	void submitResult() {
		totalGold += currentGold;
		PlayerPrefs.SetInt ("totalGold", totalGold);
	}
}
