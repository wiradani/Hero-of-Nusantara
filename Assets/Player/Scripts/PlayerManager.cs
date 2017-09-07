using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
	public GameObject newPlayer;

	void Awake(){
		SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Player"));
		GameObject x = Instantiate (newPlayer, transform.position, Quaternion.identity);
		x.AddComponent<Rigidbody2D> ();
		x.AddComponent<CircleCollider2D> ();
		x.AddComponent<Player>();

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
