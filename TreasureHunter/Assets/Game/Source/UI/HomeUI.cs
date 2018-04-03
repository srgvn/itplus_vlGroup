using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{

	static HomeUI _instance;

	public static HomeUI instance {	
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

	public Button BtnStart;

	public void StartGame ()
	{
		MainCharacterController.MainCtrl.RestartGame ();
		Time.timeScale = 1;
	}

	public void OptionBtnOnclick ()
	{
		UIController.instance.ShowOptionPanel ();
	}

	public void ExitBtnOnclick ()
	{
		Application.Quit ();
	}

	public void TutorialBtnOnclick ()
	{
		UIController.instance.ShowTutorialPanel ();
	}

	public void ShopUIBtnOnClick ()
	{
		UIController.instance.ShowShopPanel ();
	}

	public void ArchivementBtnOnClick ()
	{
		UIController.instance.ShowArchivementPanel ();
	}

}
