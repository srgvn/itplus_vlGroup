using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	int isRestart;
	int isGoBossScene;
	static UIController _instance;

	public static UIController instance {	
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


	public GameUI gameui;
	public HomeUI homeui;
	public PauseUI pauseui;
	public ResultUI resultui;
	public OptionUI optionUi;
	public TutorialPanelUI tutorialPanelUI;
	public ShopUI shopUI;
	public ArchivementUI archivementUI;

	// Use this for initialization
	void Start ()
	{
		isRestart = PlayerPrefs.GetInt ("isRestart");
		isGoBossScene = PlayerPrefs.GetInt ("isGoBossScene");
		if (isRestart == 1) {
			ShowGameUI ();
			PlayerPrefs.SetInt ("isRestart", 0);
			PlayerPrefs.Save ();
		} else if (isGoBossScene == 1) {
			ShowGameUI ();
			PlayerPrefs.SetInt ("isGoBossScene", 0);
			PlayerPrefs.Save ();
		} else {
			ShowHomeUI ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	public void ShowGameUI ()
	{
		gameui.gameObject.SetActive (true);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		archivementUI.gameObject.SetActive (false);
		Time.timeScale = 1;
		SoundController.instance.PlayGameMusic ();
		AdsController.instance.HideBanner ();
	}

	public void ShowHomeUI ()
	{
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (true);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		archivementUI.gameObject.SetActive (false);
		Time.timeScale = 0;
		SoundController.instance.PlayHomeMusic ();
	}

	public void ShowPanelPauseUI ()
	{
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (true);
		resultui.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (false);
		archivementUI.gameObject.SetActive (false);
		AdsController.instance.LoadBannerAdmob ();
		AdsController.instance.ShowBanner ();
		int randomValue = Random.Range (1, 3);
		if (randomValue < 2) {
			AdsController.instance.ShowFullAdmob ();
			AdsController.instance.HideBanner ();
		}
	}

	public void ShowPanelWin ()
	{
		gameui.gameObject.SetActive (true);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (true);
		optionUi.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (false);
		archivementUI.gameObject.SetActive (false);
		SoundController.instance.PlayEndMusic (true);
		AdsController.instance.LoadBannerAdmob ();
		AdsController.instance.ShowBanner ();
		int randomValue = Random.Range (1, 3);
		if (randomValue < 2) {
			AdsController.instance.ShowFullAdmob ();
			AdsController.instance.HideBanner ();
		}
	}

	public void ShowOptionPanel ()
	{
		resultui.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (true);
		tutorialPanelUI.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		archivementUI.gameObject.SetActive (false);
		AdsController.instance.LoadBannerAdmob ();
		AdsController.instance.ShowBanner ();
	}

	public void ShowTutorialPanel ()
	{
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (true);
		archivementUI.gameObject.SetActive (false);
		AdsController.instance.LoadBannerAdmob ();
		AdsController.instance.ShowBanner ();
	}

	public void ShowShopPanel ()
	{
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (true);
		archivementUI.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (false);
		AdsController.instance.LoadBannerAdmob ();
		AdsController.instance.ShowBanner ();
	}

	public void ShowArchivementPanel ()
	{
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);
		optionUi.gameObject.SetActive (false);
		shopUI.gameObject.SetActive (false);
		tutorialPanelUI.gameObject.SetActive (false);
		archivementUI.gameObject.SetActive (true);
		AdsController.instance.LoadBannerAdmob ();
		AdsController.instance.ShowBanner ();
	}
}
