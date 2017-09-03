using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour {
    public float hopHeight = 1.25f;
    public bool hopping = false;
    public bool ifParent = true;
    public GameObject player;
    bool playerHit = false;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPost = new Vector3(player.GetComponent<Transform>().position.x,
                                            player.GetComponent<Transform>().position.y, 0);
        StartCoroutine(Parabolic(playerPost, 0.75f));
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

    IEnumerator Parabolic(Vector3 dest, float time)
    {
        //if (hopping) yield break;

        //hopping = true;
        var startPos = transform.position;
        var timer = 0.0f;

        while (transform.position.y==transform.position.y)
        {
            var height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
            transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height;

            timer += Time.deltaTime / time;
            yield return null;
        }
        //hopping = false;
    }
}
