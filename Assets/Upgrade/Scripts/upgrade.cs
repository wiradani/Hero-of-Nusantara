using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

	public int weapon_id ;
	public int kostum_id ;

	public void pilihWeapon(){
		switch (weapon_id) {
		case 1:
			Framework_GameManager.playerData.weapon = Weapon.SPEAR;
			break;
		
		}
	}

	public void pilihKostum(){
		switch (kostum_id) {

		}
	}


}
