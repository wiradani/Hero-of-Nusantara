using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {
	Player player;
	ShieldBehaviour shield;
	public GameObject shotButtonObj, shieldButtonObj;
	Button shotButton,shieldButton;
	//GameObject shield;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		shield = GameObject.FindObjectOfType<ShieldBehaviour> ();
		shotButton = shotButtonObj.GetComponent<Button>();
		shieldButton = shieldButtonObj.GetComponent<Button>();
	}
	
	// Update is called once per frame

	public void PowerShot(){
		StartCoroutine (Cooldown (0));
		StartCoroutine (PowerShotStart());

	}

	public void Shield(){
		/*
		 *set shield sbg child player
		 *shield selalu ngikut player
		 *set skill window active
		 *wait for'duration'---
		 *set skill non-active
		*/
		shield.Activate ();
		StartCoroutine (Cooldown (1));
	}

	IEnumerator Cooldown(int i){
		if (i == 0) {
			shotButton.interactable = false;
			yield return new WaitForSeconds (15f);
			shotButton.interactable = true;
		} else if (i == 1) {
			shieldButton.interactable = false;
			yield return new WaitForSeconds (15f);
			shieldButton.interactable = true;
		}
	}

	IEnumerator PowerShotStart(){
		player.skillActive = true;
		yield return new WaitForSeconds (3f);
		player.skillActive = false;

	}
	/*
	 * IEnumerator ActivateShield(){
	 * 	shield.SetActive("true");
	 * 	yield return new WaitForSeconds (3f);
	 * 	shield.SetActive("false");
	 * }
	 */
}
