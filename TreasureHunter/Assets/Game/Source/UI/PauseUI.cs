using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
	static PauseUI _instance;

	public static PauseUI instance {	
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

	public Button BtnResume;
	public Button BtnRestart;
	public Button BtnOption;
	public Button BtnExit;

	public void ResumeGame ()
	{
		UIController.instance.ShowGameUI ();
		Time.timeScale = 1;
	}

	public void RestartGame ()
	{
		MainCharacterController.MainCtrl.RestartGame ();
	}

	public void OptionBtnOnClick ()
	{
		UIController.instance.ShowOptionPanel ();
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}

	public void HomeBtnOnClick ()
	{
		UIController.instance.ShowHomeUI ();
		Time.timeScale = 0;
	}
}
