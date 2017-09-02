using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {

	[SerializeField]
	private Text myText;

	public Framework_Weapon weapon;

	public void setText(Framework_Weapon id){
		weapon = id;
		myText.text = weapon.name;

	}

	public void clickWeapon(){
		Framework_GameManager.playerData.weapon = weapon;

		print (Framework_GameManager.playerData.weapon.name);
	}

}
