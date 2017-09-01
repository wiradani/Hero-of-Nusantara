using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	Player player;
	public Vector2 pos, playerPos;



	void Start(){
		player = GameObject.FindObjectOfType<Player>();


	}

	void Update ()
	{
		pos = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		playerPos = new Vector2 (player.transform.position.x, player.transform.position.y);
		if (pos.x > playerPos.x + 20 || pos.y<playerPos.y-10)
			Dead ();
		

	}




	void Dead(){
		Destroy (gameObject);
	}

}

