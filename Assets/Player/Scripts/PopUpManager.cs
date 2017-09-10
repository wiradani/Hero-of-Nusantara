using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour {

	public GameObject pauseWindow, helpWindow, gameOverWindow;
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
		Framework_GameManager.score = 0;
		Framework_GameManager.gold = 0;
		Framework_GameManager.instance.BackToMainMenu ();
	}
		
	public void Retry(){
		Time.timeScale = 1;
		Framework_GameManager.score = 0;
		Framework_GameManager.gold = 0;
		Framework_GameManager.instance.Retry ();
	}

	public void GameOver(){
		HideCanvas ();
		Time.timeScale = 0;
		gameOverWindow.SetActive (true);
		Text tx = gameOverWindow.GetComponentInChildren<Text> ();
		tx.text = Framework_GameManager.score.ToString();
		PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt ("Gold") + Framework_GameManager.gold);

	}
}
