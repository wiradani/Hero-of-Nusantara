using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Projectile projectile;
	public Rigidbody2D rbProjectile;

	public GameObject pointer;
	public Rigidbody2D rbPointer;
	//public Rigidbody2D rb;
	public bool isPressed = false;




	// Use this for initialization
	void Start () {
		projectile = GameObject.FindObjectOfType<Projectile> ();
		rbProjectile = projectile.GetComponent<Rigidbody2D> ();
		pointer = GameObject.FindGameObjectWithTag ("Pointer");
		rbPointer = pointer.GetComponent<Rigidbody2D> ();
		//rb = GetComponent<Rigidbody2D> ();
	}


	public float maxDragDistance = 2f;

	// Update is called once per frame
	void Update () {

		if (isPressed) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector3.Distance(mousePos, gameObject.transform.position) > maxDragDistance)
				rbPointer.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y) + (mousePos - new Vector2(gameObject.transform.position.x,gameObject.transform.position.y)).normalized * maxDragDistance;
			else
				rbPointer.position = mousePos;
		}


	}

	void OnMouseDown ()
	{
		
		isPressed = true;
		rbPointer.isKinematic = true;
	}
		
	public float forceX, forceY, power;
	public bool isLaunched;
	void OnMouseUp ()
	{
		isPressed = false;
		rbPointer.isKinematic = false;
		rbPointer.gravityScale = 1;
		forceX = gameObject.transform.position.x - rbPointer.position.x;
		forceY = gameObject.transform.position.y - rbPointer.position.y;
		rbPointer.AddForce (new Vector2 (forceX*power, forceY*power));
		isLaunched = true;
	}
}
