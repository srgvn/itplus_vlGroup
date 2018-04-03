using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanelUI : MonoBehaviour
{

	static TutorialPanelUI _instance;

	public static TutorialPanelUI instance {	
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

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ExitBtnOnClick ()
	{
		UIController.instance.ShowHomeUI ();
	}
}
