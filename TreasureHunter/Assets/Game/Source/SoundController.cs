using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

	static SoundController _instance;

	public static SoundController instance {
		get { 
			return _instance;
		}
	}

	void Awake ()
	{
		if (_instance != null)
			Destroy (this.gameObject);
		_instance = this;
		if (PlayerPrefs.GetInt ("isMuteMusic") == 1) {
			SoundController.instance.MuteMusic (true);
		}

		if (PlayerPrefs.GetInt ("isMuteSound") == 1) {
			SoundController.instance.MuteSound (true);
		}

		MusicVolumeChange (PlayerPrefs.GetFloat ("musicVolume"));
		SoundVolumeChange (PlayerPrefs.GetFloat ("soundVolume"));
	}

	public AudioSource homeMusic;
	public AudioSource gameMusic;
	public AudioSource loseMusic;
	public AudioSource winMusic;
	public AudioSource runSound;
	public AudioClip dieEffect;
	public AudioClip jumpEffect;
	public AudioClip runEffect;
	public AudioClip lightningEffect;


	public void PlayHomeMusic ()
	{
		if (!homeMusic.isPlaying)
			homeMusic.Play ();
		if (gameMusic.isPlaying)
			gameMusic.Stop ();
		if (loseMusic.isPlaying) {
			loseMusic.Stop ();
		}
		if (winMusic.isPlaying) {
			winMusic.Stop ();
		}
		if (runSound.isPlaying) {
			runSound.Stop ();
		}
	}


	public void PlayGameMusic ()
	{
		if (homeMusic.isPlaying)
			homeMusic.Stop ();
		if (!gameMusic.isPlaying)
			gameMusic.Play ();
		if (loseMusic.isPlaying) {
			loseMusic.Stop ();
		}
		if (winMusic.isPlaying) {
			winMusic.Stop ();
		}

	}

	public void PlayEndMusic (bool isWin)
	{
		if (homeMusic.isPlaying)
			homeMusic.Stop ();
		if (gameMusic.isPlaying)
			gameMusic.Stop ();
		if (!winMusic.isPlaying || !loseMusic.isPlaying) {
			if (isWin) {
				winMusic.Play ();
			} else {
				loseMusic.Play ();
			}
		}
	}

	public void PlayRunSound ()
	{
		if (!runSound.isPlaying) {
			runSound.Play ();
		}
	}


	public void PlayRunEffect ()
	{
		PlayEffect (runEffect);
	}

	public void PlayDieSound ()
	{
		PlayEffect (dieEffect);
	}

	public void PlayJumpSound ()
	{
		PlayEffect (jumpEffect);
	}

	public void PlayLightningSound ()
	{
		PlayEffect (lightningEffect);
	}

	public void PlayEffect (AudioClip effectSound)
	{
		GameObject playEffectObj = new GameObject ();
		playEffectObj.AddComponent<AudioSource> ();
		AudioSource audioSource = playEffectObj.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (effectSound);
		Destroy (playEffectObj, effectSound.length);
	}

	public void MuteMusic (bool isMute)
	{
		homeMusic.mute = isMute;
		gameMusic.mute = isMute;
		loseMusic.mute = isMute;
		winMusic.mute = isMute;
	}

	public void MuteSound (bool isMute)
	{
		AudioListener.pause = isMute;
	}

	public void MusicVolumeChange (float volume)
	{
		homeMusic.volume = gameMusic.volume = loseMusic.volume = winMusic.volume = volume;
	}

	public void SoundVolumeChange (float volume)
	{
		AudioListener.volume = volume;
	}
}
