using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Projectile projectile;
	public Rigidbody2D rbProjectile;
	public Rigidbody2D rb;
	public bool isPressed = false;




	// Use this for initialization
	void Start () {
		projectile = GameObject.FindObjectOfType<Projectile> ();
		rbProjectile = projectile.GetComponent<Rigidbody2D> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	public float maxDragDistance = 2f;

	// Update is called once per frame
	void Update () {
		if (isPressed) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector3.Distance(mousePos, rb.position) > maxDragDistance)
				rbProjectile.position = rb.position + (mousePos - rb.position).normalized * maxDragDistance;
			else
				rbProjectile.position = mousePos;
		}


	}

	void OnMouseDown ()
	{
		isPressed = true;
		rbProjectile.isKinematic = true;
	}

}
