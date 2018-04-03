using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsController : MonoBehaviour
{

	public string appIdStr = "ca-app-pub-3588763834435243~1987538471";
	public string bannerStr = "ca-app-pub-3588763834435243/4102140899";
	public string interestialStr = "ca-app-pub-3588763834435243/4728226856";
	public BannerView bannerView;
	public InterstitialAd interstial;

	static AdsController _instance;

	public static AdsController instance {
		get { 
			return _instance;
		}
	}

	void Awake ()
	{
		if (_instance == null) {
			_instance = this;
		} else if (_instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void LoadFullAdmob ()
	{
		interstial = new InterstitialAd (interestialStr);
		AdRequest request = new AdRequest.Builder ().AddTestDevice (AdRequest.TestDeviceSimulator).Build ();
		interstial.LoadAd (request);
	}

	public void ShowFullAdmob ()
	{
		LoadFullAdmob ();
		interstial.Show ();
	}

	public void LoadBannerAdmob ()
	{
		if (bannerView == null) {
			bannerView = new BannerView (bannerStr, AdSize.Banner, AdPosition.Top);
			AdRequest request = new AdRequest.Builder ().AddTestDevice (AdRequest.TestDeviceSimulator).Build ();
			bannerView.LoadAd (request);
		}
	}

	public void ShowBanner ()
	{
		bannerView.Show ();
	}

	public void HideBanner ()
	{
		if (bannerView != null) {
			bannerView.Hide ();
		}
	}
}
