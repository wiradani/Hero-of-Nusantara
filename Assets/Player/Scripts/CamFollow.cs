using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
<<<<<<< HEAD

	// Use this for initialization
=======
>>>>>>> master
	public Vector3 offset;
	Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
<<<<<<< HEAD
		offset = new Vector3 (3,0.3f,gameObject.transform.position.z);
=======
		offset = new Vector3 (player.transform.position.x*-1,2,gameObject.transform.position.z);
>>>>>>> master
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position + offset;
	}
}
