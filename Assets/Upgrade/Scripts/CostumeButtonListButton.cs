using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeButtonListButton : MonoBehaviour {

	[SerializeField]
	private Text myText;

	public Framework_CostumeData costume;

	public void setText(Framework_CostumeData id){
		costume = id;
		myText.text = costume.name;

	}

	public void clickWeapon(){
		Framework_GameManager.playerData.costume = costume;
		CostumeButtonListControl.instance.avatar.UpdatePlayerAppeareance ();
		print (Framework_GameManager.playerData.costume.name);
	}
}
