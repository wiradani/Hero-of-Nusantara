using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour {
    public bool hopping = false;
    public bool ifParent = true;
    public GameObject player;
    public GameObject enemy;
    public static EnemyType enemyType;
    bool playerHit = false;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Parabolic(1.25f,0.75f));
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name=="player")
        {
            hopping = false;
            playerHit = true;
            if(!ifParent) Destroy(this.gameObject);
        }
    }

    IEnumerator Parabolic(float hopHeight, float time)
    {
        //if (hopping) yield break;

        //hopping = true;
        var startPos = transform.position;
        var timer = 0.0f;
        Vector3 playerPost = new Vector3(player.GetComponent<Transform>().position.x,
                                            player.GetComponent<Transform>().position.y, 0);

        while (transform.position.y==transform.position.y)
        {
            if (transform.position.y < player.transform.position.y && playerPost != player.transform.position)
                Destroy(this.gameObject);
            var height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
            transform.position = Vector3.Lerp(startPos, playerPost, timer) + Vector3.up * height;

            timer += Time.deltaTime / time;
            yield return null;
        }
        //hopping = false;
    }

}
