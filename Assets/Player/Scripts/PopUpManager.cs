using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour {

	public GameObject pauseWindow, helpWindow;
	public GameObject uiCanvas;

	void HideCanvas(){
		uiCanvas.SetActive (false);
	}

	void ShowCanvas(){
		uiCanvas.SetActive (true);
	}

	public void Pause(){
		pauseWindow.SetActive(true);
		Time.timeScale = 0;
		HideCanvas ();
	}
	public void Resume(){
		pauseWindow.SetActive (false);
		Time.timeScale = 1;
		ShowCanvas ();
	}

	public void OpenHelp(){
		helpWindow.SetActive (true);
		Time.timeScale = 0;
		HideCanvas ();
	}

	public void CloseHelp(){
		helpWindow.SetActive (false);
		Time.timeScale = 1;
		ShowCanvas ();
	}

	public void BacktoMenu(){
		Time.timeScale = 1;
		Framework_GameManager.instance.BackToMainMenu ();
	}
		
}
