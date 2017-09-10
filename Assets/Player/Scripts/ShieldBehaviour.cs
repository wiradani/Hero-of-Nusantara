using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {
	SpriteRenderer sr;
	CircleCollider2D col;
	Player player;
	BoxCollider2D playerCol;
	Vector3 offset;
	EnemyBehavior[] enemy;
	public bool immortal=false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		enemy = GameObject.FindObjectsOfType<EnemyBehavior> ();
		playerCol = player.GetComponent<BoxCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();
		col = GetComponent<CircleCollider2D> ();
		sr.enabled = false;
		col.enabled = false;
		offset = new Vector3 (1, 0, gameObject.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.gameObject.transform.position + offset;

	}

	public void Activate(){
		StartCoroutine (ShieldDuration ());
	
	}

	public void Deactivate(){
		immortal = false;
		sr.enabled = false;
		col.enabled = false;
	}
	IEnumerator ShieldDuration(){
		immortal = true;
		sr.enabled = true;
		col.enabled = true;
		yield return new WaitForSeconds (5f);
		Deactivate ();
	}

	void OnCollisionEnter2D(Collision2D col){
		
			col.gameObject.SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
		print("collideEnter");
		
	}
	void OnCollisionStay2d(Collision2D col){
		print("collideStay");
			col.gameObject.SendMessage ("Dead", SendMessageOptions.DontRequireReceiver);
	}
}
