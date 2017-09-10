using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour {

	public GameObject window;	
	public Text messegeField;

	public void Show(string messege){
		messegeField.text = messege;
		window.SetActive (true);
	}

	public void Hide(){
		window.SetActive (false);
	}
}
