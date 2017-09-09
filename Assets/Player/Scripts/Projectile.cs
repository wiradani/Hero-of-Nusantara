using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	Player player;
	public Vector2 pos, playerPos;

	public int damage=1,weaponDamage=0, totalDamage;
	/*
	 *base damage = 1
	 *total damage = damage+weapon dmg
	 *skill active->total damage =total damage*2
	 *
	 *cek trigger
	 *kalo trigger punya script musuh
	 *send dmg('total dmg)'
	 */


	void Start(){
		player = GameObject.FindObjectOfType<Player>();
		//if(player.skillActive)
		totalDamage = damage+weaponDamage;

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

	void OnCollisionEnter2D(Collision2D col){
		col.gameObject.SendMessage("GetDamage", totalDamage, SendMessageOptions.DontRequireReceiver);
		Dead();
	}
}

