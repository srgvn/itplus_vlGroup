using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

	static UIController _instance;
	public static UIController instance{	
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


	public GameUI gameui;
	public HomeUI homeui;
	public PauseUI pauseui;
	public ResultUI resultui;

		// Use this for initialization
	void Start () {
		ShowHomeUI ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ShowGameUI(){
		gameui.gameObject.SetActive (true);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);


	}
	public void ShowHomeUI(){
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (true);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (false);

	}
	public void ShowPanelPauseUI(){
		gameui.gameObject.SetActive (false);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (true);
		resultui.gameObject.SetActive (false);
		PauseUI.instance.BtnMusic.gameObject.SetActive (false);
		PauseUI.instance.BtnBack.gameObject.SetActive (false);

	}
	public void ShowPanelWin(){
		gameui.gameObject.SetActive (true);
		homeui.gameObject.SetActive (false);
		pauseui.gameObject.SetActive (false);
		resultui.gameObject.SetActive (true);

	}

}
