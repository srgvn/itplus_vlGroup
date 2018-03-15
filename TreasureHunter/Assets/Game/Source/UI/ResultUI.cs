using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultUI : MonoBehaviour {

	// Use this for initialization
	static ResultUI _instance;
	public static ResultUI instance{	
		get{ 
			return _instance;
		}
	}
	void Awake(){
		if (_instance != null) {
			Destroy (this.gameObject);
		}
		_instance = this;	
	}
	public Button BtnHome;
	public Button BtnPlay;
	public Button BtnRestart;
	public Button BtnShare;
	public Button BtnExit;
	public Text ResultText;
	public Image WinCrown;
	public Image FailCrown;

	public Image Keys;
	public Text PointKeys;
	public Text AllKeys;

	public Image Coin;
	public Text TCoin;


	public Image Skull;
	public Text PointSkull;
	public Text SkullKill;

	public void ShowWinResult(){
		BtnPlay.interactable = false;
		FailCrown.gameObject.SetActive (false);

		ResultText.text = "WIN";

	}

	public void ShowFailedResult(){
		FailCrown.gameObject.SetActive (true);
		ResultText.text = "FAILED";
	}

	public void ButtonHome(){
		UIController.instance.ShowHomeUI ();
	}

	public void ButtonRestart(){
		SceneManager.LoadScene ("GameScene");
	}
	public void ButtonShare(){
		
	}
	public void ButtonExit(){
		Application.Quit ();
	}
}
