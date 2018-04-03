using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

	public int skinActive;
	int totalGold;
	int isManSkinOwned;
	int isGirlSkinOwned;
	int isKnightSkinOwned;
	int isDogSkinOwned;
	bool[] skinOwnedArr;
	public Button manSkinBtn;
	public Button girlSkinBtn;
	public Button knightSkinBtn;
	public Button dogSkinBtn;
	static ShopUI _instance;

	public Button[] btnArr;

	public static ShopUI instance {	
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
		skinActive = PlayerPrefs.GetInt ("skinActive");
		totalGold = PlayerPrefs.GetInt ("totalGold");
		isManSkinOwned = 1;
		isGirlSkinOwned = PlayerPrefs.GetInt ("isGirlSkinOwned");
		isKnightSkinOwned = PlayerPrefs.GetInt ("isKnightSkinOwned");
		isDogSkinOwned = PlayerPrefs.GetInt ("isDogSkinOwned");
		getSkinOwned ();
		SkinActiveDisable (skinActive);
		SkinOwnedSet (isManSkinOwned, manSkinBtn, 0, 0);
		SkinOwnedSet (isGirlSkinOwned, girlSkinBtn, 4000, 1);
		SkinOwnedSet (isKnightSkinOwned, knightSkinBtn, 10000, 2);
		SkinOwnedSet (isDogSkinOwned, dogSkinBtn, 20000, 3);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ExitBtnOnClick ()
	{
		UIController.instance.ShowHomeUI ();
	}

	void SkinOwnedSet (int isOwned, Button btn, int value, int activeID)
	{
		if (isOwned == 1) {
			if (skinActive == activeID) {
				btn.interactable = false;
			} else {
				btn.interactable = true;
			}
			btn.transform.GetChild (1).GetComponent<Button> ().interactable = false;
			btn.transform.GetChild (1).transform.GetChild (0).GetComponent<Image> ().enabled = false;
			btn.transform.GetChild (1).transform.GetChild (1).GetComponent<Text> ().text = "OWNED";
		} else {
			btn.interactable = false;
			if (totalGold < value) {
				btn.transform.GetChild (1).GetComponent<Button> ().interactable = false;
			} else {
				btn.transform.GetChild (1).GetComponent<Button> ().interactable = true;
			}
			btn.transform.GetChild (1).transform.GetChild (0).GetComponent<Image> ().enabled = true;
			btn.transform.GetChild (1).transform.GetChild (1).GetComponent<Text> ().text = value.ToString ();
		}
	}

	void SkinActiveDisable (int skinActive)
	{
		for (int i = 0; i < 4; i++) {
			if (skinActive == i) {
				btnArr [i].interactable = false;
				btnArr [i].transform.GetChild (0).transform.GetChild (0).GetComponent<Image> ().enabled = true;
			} else {
				if (skinOwnedArr [i]) {
					btnArr [i].interactable = true;
				} else {
					btnArr [i].interactable = false;
				}
				btnArr [i].transform.GetChild (0).transform.GetChild (0).GetComponent<Image> ().enabled = false;
			}
		}
	}

	public void SkinBtnOnclick (int skinClick)
	{
		skinActive = skinClick;
		getSkinOwned ();
		SkinActiveDisable (skinActive);
		PlayerPrefs.SetInt ("skinActive", skinActive);
		PlayerPrefs.Save ();
	}

	public void SkinBuyBtnOnClick (int skinBought)
	{
		string skinBoughtStr = "";
		for (int i = 0; i < 4; i++) {
			if (skinBought == i) {
				btnArr [i].interactable = true;
				btnArr [i].transform.GetChild (1).transform.GetChild (0).GetComponent<Image> ().enabled = false;
				btnArr [i].transform.GetChild (1).transform.GetChild (1).GetComponent<Text> ().text = "OWNED";
				btnArr [i].transform.GetChild (1).GetComponent<Button> ().interactable = false;
			}
		}
		if (skinBought == 0) {
			skinBoughtStr = "isManSkinOwned";
		} else if (skinBought == 1) {
			skinBoughtStr = "isGirlSkinOwned";
		} else if (skinBought == 2) {
			skinBoughtStr = "isKnightSkinOwned";
		} else if (skinBought == 3) {
			skinBoughtStr = "isDogSkinOwned";
		}
		CommitTransaction (skinBoughtStr);
	}

	void CommitTransaction (string skinBought)
	{
		PlayerPrefs.SetInt ("totalGold", totalGold);
		PlayerPrefs.SetInt (skinBought, 1);
		PlayerPrefs.Save ();
	}

	void getSkinOwned ()
	{
		isGirlSkinOwned = PlayerPrefs.GetInt ("isGirlSkinOwned");
		isKnightSkinOwned = PlayerPrefs.GetInt ("isKnightSkinOwned");
		isDogSkinOwned = PlayerPrefs.GetInt ("isDogSkinOwned");
		skinOwnedArr = new bool[4];
		if (isManSkinOwned == 1) {
			skinOwnedArr [0] = true;
		} else {
			skinOwnedArr [0] = false;
		}

		if (isGirlSkinOwned == 1) {
			skinOwnedArr [1] = true;
		} else {
			skinOwnedArr [1] = false;
		}

		if (isKnightSkinOwned == 1) {
			skinOwnedArr [2] = true;
		} else {
			skinOwnedArr [2] = false;
		}

		if (isDogSkinOwned == 1) {
			skinOwnedArr [3] = true;
		} else {
			skinOwnedArr [3] = false;
		}
	}
}
