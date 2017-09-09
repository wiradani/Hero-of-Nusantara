using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	public Vector3 offset;
	Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
		offset = new Vector3 (3,0.3f,gameObject.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position + offset;
	}
}
