using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController _instance;
	public static GameController Instance {
		get { 
			return _instance;
		}
	}

//	void Awake() {
//		if (_instance != null) {
//			Destroy (this.gameObject);
//		}
//		_instance = this;
//	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndGame(){
		//Time.timeScale = 0;
		Debug.Log("EndGame");
	}
}
