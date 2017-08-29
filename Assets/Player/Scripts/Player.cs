using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int testArea;
	public float leftTouchArea, velocity, yPoint;
	Rigidbody2D rb2d;
	public GameObject hook;
	public bool isMoving, isReloading;
	Projectile projectile;
	public GameObject bullet;


	// Use this for initialization
	void Start () {
		isReloading = false;
		isMoving = false;
		projectile = GameObject.FindObjectOfType<Projectile> ();
		velocity = 2f;
		rb2d = GetComponent<Rigidbody2D> ();
		testArea = 6;
		leftTouchArea = Screen.width / testArea;
		yPoint = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector2(gameObject.transform.position.x,yPoint);
		hook.transform.position = new Vector2 (gameObject.transform.position.x+1, gameObject.transform.position.y);

		if (!projectile.isPressed) {
			if (Input.mousePosition.x < leftTouchArea && Input.GetMouseButton (0)) {

				isMoving = true;
				Destroy (bullet);
				Debug.Log ("left");
				rb2d.velocity = new Vector2 (velocity * -1, rb2d.velocity.y);


			} else {
				isMoving = false;
				if (Input.mousePosition.x < leftTouchArea&&Input.GetMouseButtonUp (0))
					isReloading = true;

			}
		}
		if (!isMoving && isReloading) {
			Instantiate (bullet, hook.transform.position, Quaternion.identity);
			isReloading = false;
		}


	}

}
