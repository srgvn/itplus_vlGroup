using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook;
using Facebook.Unity;
using System;

public class FaceBookController : MonoBehaviour
{
	public Button LoginBtn;

	void Awake ()
	{
		if (!FB.IsInitialized) {
			FB.Init ();
		} else {
			FB.ActivateApp ();
		}
	}

	void SetInit ()
	{
		Debug.Log ("Face book init done!");
		if (FB.IsLoggedIn) {
		
		} else {
			
		}
	}

	public void Login ()
	{
		FB.LogInWithReadPermissions (callback: OnLogin);
	}

	void OnLogin (ILoginResult result)
	{
		if (FB.IsLoggedIn) {
			LoginBtn.interactable = false;
		} else {
			LoginBtn.interactable = true;
		}
	}

	public void ShareFB ()
	{
		if (FB.IsLoggedIn) {
			FB.ShareLink (
				contentTitle: "So Cool, Man!",
				contentURL: new System.Uri ("http://wwww.facebook.com/summer.rajn"),
				contentDescription: "Check out this game now!",
				callback: OnShare
			);
		} else {
			Login ();
		}
	}

	void OnShare (IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("ShareLink Error: " + result.Error);
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log (result.PostId);
		} else {
			Debug.Log ("Share complete");
		}
	}
		
}
