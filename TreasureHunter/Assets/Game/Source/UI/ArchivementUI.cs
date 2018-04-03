using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivementUI : MonoBehaviour
{

	public Button[] archiBtn;

	int totalGold;
	int keyCollected;
	int bossKilled;
	int chestCollected;

	int[] isUnlockArchi = new int[4];

	// Use this for initialization
	void Start ()
	{
		totalGold = PlayerPrefs.GetInt ("totalGold");
		bossKilled = PlayerPrefs.GetInt ("bossKill");
		keyCollected = PlayerPrefs.GetInt ("keyCollected");
		chestCollected = PlayerPrefs.GetInt ("chestCollected");
		CheckLock ();

		for (int i = 0; i < 4; i++) {
			isUnlockArchi [i] = PlayerPrefs.GetInt ("isUnlockArchi" + (i + 1));
			archiBtn [i].interactable = false;
		}

		UnLockButton ();
	}

	void CheckLock ()
	{
		if (PlayerPrefs.GetInt ("totalGold") >= 100000) {
			PlayerPrefs.SetInt ("isUnlockArchi1", 1);
			PlayerPrefs.SetInt ("totalGold", totalGold + 1000);
		}

		if (PlayerPrefs.GetInt ("bossKill") >= 5) {
			PlayerPrefs.SetInt ("isUnlockArchi2", 1);
			PlayerPrefs.SetInt ("totalGold", totalGold + 3000);
		}

		if (PlayerPrefs.GetInt ("keyCollected") >= 20) {
			PlayerPrefs.SetInt ("isUnlockArchi3", 1);
			PlayerPrefs.SetInt ("totalGold", totalGold + 7000);
		}

		if (PlayerPrefs.GetInt ("chestCollected") >= 10) {
			PlayerPrefs.SetInt ("isUnlockArchi4", 1);
			PlayerPrefs.SetInt ("totalGold", totalGold + 10000);
		}
		PlayerPrefs.Save ();
	}

	void UnLockArchiment (Button btn, bool isLock)
	{
		btn.transform.GetChild (2).gameObject.SetActive (isLock);
	}

	void UnLockButton ()
	{
		for (int i = 0; i < 4; i++) {
			if (isUnlockArchi [i] == 1) {
				UnLockArchiment (archiBtn [i], false);
			} else {
				UnLockArchiment (archiBtn [i], true);
			}
		}
	}

	public void ExitBtnOnClick ()
	{
		UIController.instance.ShowHomeUI ();
	}
}
