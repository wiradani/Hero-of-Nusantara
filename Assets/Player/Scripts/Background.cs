using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour {
	Player player;
	public GameObject bg;
	public Vector3 offset;
	Renderer rend;
	float distance;


	private void Start()
	{
		player = GameObject.FindObjectOfType<Player> ();
		rend = GetComponent<Renderer> ();
		offset.x = rend.bounds.size.x;
	}

	private void Update()
	{
		distance = transform.position.x - player.transform.position.x;
		if (distance > 40)
			Destroy (gameObject);
			
	}﻿

	void OnTriggerEnter2D(Collider2D col){
		if (col.GetComponent<Player> ()!= null) {
			SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Player"));
			GameObject x=Instantiate (bg, transform.position - offset, Quaternion.identity);
		}
	}
}
