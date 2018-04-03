using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{

	public int keyCollected;
	public int bossKilled;
	bool isDead;
	Animator animator;
	public int skinActive;
	public bool isJumping = false;
	private static MainCharacterController _mainCtrl;
	public int totalGold;
	public int currentGold;
	public int chestCollected;

	public static MainCharacterController MainCtrl {
		get { 
			return _mainCtrl;
		}
	}

	void Awake ()
	{
		if (_mainCtrl != null) {
			Destroy (this.gameObject);
		}
		_mainCtrl = this;
		skinActive = PlayerPrefs.GetInt ("skinActive");
	}
	// Use this for initialization
	void Start ()
	{
		loadResult ();
		animator = gameObject.GetComponent<Animator> ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		} else if (tagName.Equals ("BushTrap") || tagName.Equals ("SpikeTrap") || tagName.Equals ("RockTrapDead") || tagName.Equals ("Monster") || tagName.Equals ("UnderWater")) {
			Die ();
		} else if (tagName.Equals ("Door")) {
			if (keyCollected != 5) {
				Die ();
			} else {
				submitResult ();
				PlayerPrefs.SetInt ("isGoBossScene", 1);
				PlayerPrefs.Save ();
				SceneManager.LoadScene ("BossScene");
			}
		} else if (col.gameObject.name.Equals ("Chest")) {
			currentGold += 5000;
			chestCollected++;
			EndGame (true);
		}

		if (col.gameObject.name.Equals ("GroundUp8")) {
			gameObject.transform.SetParent (col.gameObject.transform);
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = true;
		}
		if (col.gameObject.name.Equals ("GroundUp8")) {
			gameObject.transform.SetParent (null);
		}
	}

	void OnCollisionStay2D (Collision2D col)
	{
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("Ground")) {
			isJumping = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		string tagName = col.gameObject.tag;
		if (tagName.Equals ("RockTrapDead") || tagName.Equals ("Piranha") || tagName.Equals ("DeadPoint")) {
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

	void Die ()
	{
		isDead = true;
		animator.SetBool ("isDead", true);
		animator.SetBool ("isIdle", false);
		animator.SetBool ("isRunFwd", false);
		animator.SetBool ("isJump", false);
		SoundController.instance.PlayDieSound ();
		EndGame (false);
	}

	void EndGame (bool isWin)
	{
		Time.timeScale = 0;
		UIController.instance.ShowPanelWin ();
		if (isWin) {
			ResultUI.instance.ShowWinResult ();
		} else {
			ResultUI.instance.ShowFailedResult ();
		}
		ResultUI.instance.PointKeys.text = keyCollected.ToString ();
		ResultUI.instance.TCoin.text = currentGold.ToString ();
		ResultUI.instance.PointSkull.text = bossKilled.ToString ();
		submitResult ();

	}

	void loadResult ()
	{
		if (PlayerPrefs.HasKey ("totalGold")) {
			totalGold = PlayerPrefs.GetInt ("totalGold");
		}
	}

	void submitResult ()
	{
		Debug.Log (totalGold);
		totalGold += currentGold;
		PlayerPrefs.SetInt ("totalGold", totalGold);
		PlayerPrefs.SetInt ("bossKill", PlayerPrefs.GetInt ("bossKill") + bossKilled);
		PlayerPrefs.SetInt ("keyCollected", PlayerPrefs.GetInt ("keyCollected") + keyCollected);
		PlayerPrefs.SetInt ("chestCollected", PlayerPrefs.GetInt ("chestCollected") + chestCollected);
		PlayerPrefs.Save ();
		Debug.Log (PlayerPrefs.GetInt ("totalGold") + "-");
	}

	public void RestartGame ()
	{
		PlayerPrefs.SetInt ("isRestart", 1);
		PlayerPrefs.Save ();
		SceneManager.LoadScene ("GameScene");
	}
}
