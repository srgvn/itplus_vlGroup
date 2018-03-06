using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	private static MapController _mapCtrl;
	public static MapController MapCtrl {
		get { 
			return _mapCtrl;
		}
	}

	void Awake() {
		if (_mapCtrl != null) {
			Destroy (this.gameObject);
		}
		_mapCtrl = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
