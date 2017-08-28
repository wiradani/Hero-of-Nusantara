using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade : MonoBehaviour {

	public int weapon_id ;

	public void pilihWeapon(){
		switch (weapon_id) {
		case 1:
			Framework_GameManager.playerData.weapon = Weapon.SPEAR;
			break;
		
	
		}
	}
}
