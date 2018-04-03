using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	int skinActive;
	private static GameController _instance;
	public GameObject player;
	public GameObject[] playerArr;

	public static GameController Instance {
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
		skinActive = PlayerPrefs.GetInt ("skinActive");
		changeSkin (skinActive);
	}

	public void changeSkin (int skinActive)
	{
		for (int i = 0; i < 4; i++) {
			if (i == skinActive) {
				playerArr [i].SetActive (true);
				player = playerArr [i];
			} else {
				playerArr [i].SetActive (false);
			}
		}
	}
}
