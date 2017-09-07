using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {
	SpriteRenderer sr;
	CircleCollider2D col;
	Player player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
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

	void Activate(){
		StartCoroutine (ShieldDuration ());
	
	}

	void Deactivate(){
		sr.enabled = false;
		col.enabled = false;
	}
	IEnumerator ShieldDuration(){
		sr.enabled = true;
		col.enabled = true;
		yield return new WaitForSeconds (3f);
		Deactivate ();
	}
}
