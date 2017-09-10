using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credits_button : MonoBehaviour {

	public GameObject window;
	public GameObject lain;

	public void show(){
		window.SetActive (true);
		lain.SetActive (false);
	}

	public void hide(){
		window.SetActive (false);
		lain.SetActive (true);
	}


}
