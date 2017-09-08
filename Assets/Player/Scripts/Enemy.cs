using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float velocity, elapsedTime, moveTime;
	public int delay;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (Move ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Move(){
		yield return new WaitForSeconds (delay);	//Delay sebelom musuh jalan lagi
		elapsedTime = 0f;	//counter
		while (elapsedTime < moveTime) { //lama musuh gerak
			rb2d.velocity = new Vector2 (velocity*-1, rb2d.velocity.y);	//besar perpindahan
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		StartCoroutine (Move ());

	}

	void Dead(){
		Destroy (gameObject);
	}
}
