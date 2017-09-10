using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_button : MonoBehaviour {


	public void  backButton(){
		Framework_GameManager.instance.BackFromUpgrade();
	}
}
