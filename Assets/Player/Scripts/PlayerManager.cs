using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
	public GameObject newPlayer, Player;
	Transform parent;
	public bool buttonPress=false;


	void Awake(){
		PlayerPrefs.SetInt ("StageScore", 0);
		parent = Player.GetComponent<Transform> ();
		parent.localScale = new Vector3 (0.5f, 0.5f, parent.localScale.z);
		SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Player"));
		GameObject x = Instantiate (newPlayer, transform.position, Quaternion.identity, parent);

		//x.AddComponent<Rigidbody2D> ();
		//x.AddComponent<CircleCollider2D> ();
		//x.AddComponent<Player>();

	}


	//public void PressButton(){
		//button
	//}

}
