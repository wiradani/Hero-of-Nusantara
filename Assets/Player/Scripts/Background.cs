using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour {
	public GameObject bg;
	public Vector3 offset;


	private void Start()
	{
		
	}

	private void Update()
	{
		
			
	}﻿

	void OnTriggerEnter2D(Collider2D col){
		if (col.GetComponent<Player> ()!= null) {
			SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Player"));
			GameObject x=Instantiate (bg, transform.position - offset, Quaternion.identity);
		}
	}
}
