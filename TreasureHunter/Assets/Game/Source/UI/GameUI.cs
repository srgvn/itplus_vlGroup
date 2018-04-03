using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	static GameUI _instance;

	public static GameUI instance {	
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


	public Button BtnPause;

	public void PauseGame ()
	{
		Time.timeScale = 0;
		UIController.instance.ShowPanelPauseUI ();
	}
}
