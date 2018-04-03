using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
	static OptionUI _instance;
	public bool isMusicMute;
	public bool isSoundMute;
	public Button muteSoundBtn;
	public Button muteMusicBtn;
	public Slider musicVolume;
	public Slider soundVolume;

	public static OptionUI instance {	
		get { 
			return _instance;
		}
	}

	void Awake ()
	{
		isMusicMute = PlayerPrefs.GetInt ("isMuteMusic") == 1 ? true : false;
		isSoundMute = PlayerPrefs.GetInt ("isMuteSound") == 1 ? true : false;
		if (_instance != null) {
			Destroy (this.gameObject);
		}
		_instance = this;
		if (PlayerPrefs.GetInt ("isMuteMusic") == 1) {
			Color color = muteMusicBtn.GetComponent<Image> ().color;
			color.g = 0;
			muteMusicBtn.GetComponent<Image> ().color = color;
		}

		if (PlayerPrefs.GetInt ("isMuteSound") == 1) {
			Color color = muteSoundBtn.GetComponent<Image> ().color;
			color.g = 0;
			muteSoundBtn.GetComponent<Image> ().color = color;
		}

		musicVolume.value = PlayerPrefs.GetFloat ("musicVolume");
		soundVolume.value = PlayerPrefs.GetFloat ("soundVolume");
	}

	public void ExitBtnOnClick ()
	{
		instance.gameObject.SetActive (false);
	}

	public void MuteMusicBtnOnClick ()
	{
		Color color = muteMusicBtn.GetComponent<Image> ().color;
		;
		SoundController.instance.MuteMusic (!isMusicMute);
		musicVolume.interactable = isMusicMute;
		if (isMusicMute) {
			color.g = 255;
			muteMusicBtn.GetComponent<Image> ().color = color;
			PlayerPrefs.SetInt ("isMuteMusic", 0);
		} else {
			color.g = 0;
			muteMusicBtn.GetComponent<Image> ().color = color;
			PlayerPrefs.SetInt ("isMuteMusic", 1);
		}
		isMusicMute = !isMusicMute;
		PlayerPrefs.Save ();
	}

	public void MuteSoundBtnOnClick ()
	{
		Color color = muteSoundBtn.GetComponent<Image> ().color;
		soundVolume.interactable = isSoundMute;
		SoundController.instance.MuteSound (!isSoundMute);
		if (isSoundMute) {
			color.g = 255;
			muteSoundBtn.GetComponent<Image> ().color = color;
			PlayerPrefs.SetInt ("isMuteSound", 0);
		} else {
			color.g = 0;
			muteSoundBtn.GetComponent<Image> ().color = color;
			PlayerPrefs.SetInt ("isMuteSound", 1);
		}
		isSoundMute = !isSoundMute;
		PlayerPrefs.Save ();
	}

	public void MusicSliderValueOnChange ()
	{
		SoundController.instance.MusicVolumeChange (musicVolume.value);
		PlayerPrefs.SetFloat ("musicVolume", musicVolume.value);
		PlayerPrefs.Save ();
	}

	public void SoundSliderValueOnChange ()
	{
		SoundController.instance.SoundVolumeChange (soundVolume.value);
		PlayerPrefs.SetFloat ("soundVolume", soundVolume.value);
		PlayerPrefs.Save ();
	}
}
