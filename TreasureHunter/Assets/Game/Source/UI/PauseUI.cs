using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {
	static PauseUI _instance;
	public static PauseUI instance{	
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
	public Button BtnResume;
	public Button BtnRestart;
	public Button BtnOption;
	public Button BtnExit;
	// Use this for initialization
	public Text TextMusic;
	public Button BtnMusic;

	public Button BtnEffectSound;
	public Text TextSound;

	public Button BtnBack;
	public Text TextBack;

	public Button BtnHelp;
	public Text TextHelp;

	public Slider MusicSlider;
	public Slider SoundEffectSlider;

	public Text TextTutorial;
	public Button BtnBackToSound;

	public void ResumeGame(){
		UIController.instance.ShowGameUI ();
	}
	public void RestartGame(){
		SceneManager.LoadScene ("GameScene");
	}
	public void OptionGame(){
		BtnResume.gameObject.SetActive (false);
		BtnRestart.gameObject.SetActive (false);
		BtnOption.gameObject.SetActive (false);
		BtnExit.gameObject.SetActive (false);

		BtnMusic.gameObject.SetActive (true);
		TextMusic.gameObject.SetActive (true);

		BtnEffectSound.gameObject.SetActive (true);
		TextSound.gameObject.SetActive (true);

		BtnBack.gameObject.SetActive (true);
		TextBack.gameObject.SetActive (true);

		BtnHelp.gameObject.SetActive (true);
		TextHelp.gameObject.SetActive (true); 

		MusicSlider.gameObject.SetActive (true);
		SoundEffectSlider.gameObject.SetActive (true);



	}
	public void ExitGame (){
		Application.Quit ();
	}
	public void PressMusic(){
		
	}
	public void PressSoundEffect(){
	}
	public void ButtonBack(){
		BtnResume.gameObject.SetActive (true);
		BtnRestart.gameObject.SetActive (true);
		BtnOption.gameObject.SetActive (true);
		BtnExit.gameObject.SetActive (true);

		BtnMusic.gameObject.SetActive (false);
		TextMusic.gameObject.SetActive (false);

		BtnEffectSound.gameObject.SetActive (false);
		TextSound.gameObject.SetActive (false);

		BtnBack.gameObject.SetActive (false);
		TextBack.gameObject.SetActive (false);

		BtnHelp.gameObject.SetActive (false);
		TextHelp.gameObject.SetActive (false); 

		MusicSlider.gameObject.SetActive (false);
		SoundEffectSlider.gameObject.SetActive (false);

	}
	public void ButtonHelp(){
		TextTutorial.gameObject.SetActive (true);
		BtnBackToSound.gameObject.SetActive (true);
		BtnResume.gameObject.SetActive (false);
		BtnRestart.gameObject.SetActive (false);
		BtnOption.gameObject.SetActive (false);
		BtnExit.gameObject.SetActive (false);

		BtnMusic.gameObject.SetActive (false);
		TextMusic.gameObject.SetActive (false);

		BtnEffectSound.gameObject.SetActive (false);
		TextSound.gameObject.SetActive (false);

		BtnBack.gameObject.SetActive (false);
		TextBack.gameObject.SetActive (false);

		BtnHelp.gameObject.SetActive (false);
		TextHelp.gameObject.SetActive (false); 

		MusicSlider.gameObject.SetActive (false);
		SoundEffectSlider.gameObject.SetActive (false);
	}

	public void ButtonBackToSound(){
		BtnResume.gameObject.SetActive (false);
		BtnRestart.gameObject.SetActive (false);
		BtnOption.gameObject.SetActive (false);
		BtnExit.gameObject.SetActive (false);

		BtnMusic.gameObject.SetActive (true);
		TextMusic.gameObject.SetActive (true);

		BtnEffectSound.gameObject.SetActive (true);
		TextSound.gameObject.SetActive (true);

		BtnBack.gameObject.SetActive (true);
		TextBack.gameObject.SetActive (true);

		BtnHelp.gameObject.SetActive (true);
		TextHelp.gameObject.SetActive (true); 

		MusicSlider.gameObject.SetActive (true);
		SoundEffectSlider.gameObject.SetActive (true);

		TextTutorial.gameObject.SetActive (false);
		BtnBackToSound.gameObject.SetActive (false);
	}
}
