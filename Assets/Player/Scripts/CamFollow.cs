using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	// Use this for initialization

	public Vector3 offset;
	Player player;
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		cam.orthographicSize = 8.3f;
		player = GameObject.FindObjectOfType<Player>();
		offset = new Vector3 (6,0.3f,gameObject.transform.position.z);

	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindObjectOfType<Player>();
		}
		gameObject.transform.position = player.transform.position + offset;
	}
}
