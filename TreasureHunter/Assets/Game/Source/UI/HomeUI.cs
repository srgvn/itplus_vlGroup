using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour {

	static HomeUI _instance;
	public static HomeUI instance{	
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
	public Button BtnStart;
	public void StartGame(){
		UIController.instance.ShowGameUI ();
	}

}
