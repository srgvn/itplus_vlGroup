using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

	private static MapController _mapCtrl;

	public static MapController MapCtrl {
		get { 
			return _mapCtrl;
		}
	}

	void Awake ()
	{
		if (_mapCtrl != null) {
			Destroy (this.gameObject);
		}
		_mapCtrl = this;
	}

}
