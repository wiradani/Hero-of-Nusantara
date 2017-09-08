using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesProjectile : MonoBehaviour {
	
	public Rigidbody2D rb;
	public Rigidbody2D hook;
	GameObject hookObject;
	public float forceX, forceY;
	public float releaseTime = .15f;
	public float maxDragDistance = 2f;
	public float power;
	public bool isLaunched = false;


	public bool isPressed = false;

	void Start(){
		hookObject = GameObject.FindGameObjectWithTag ("Hook");
		hook = hookObject.GetComponent<Rigidbody2D> ();
		//gameObject.transform.position = new Vector2 (hook.transform.position.x,hook.transform.position.y);

	}

	void Update ()
	{


		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}
	}

	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;
		rb.gravityScale = 1;
		forceX = hook.position.x - rb.position.x;
		forceY = hook.position.y - rb.position.y;
		rb.AddForce (new Vector2 (forceX*power, forceY*power));
		isLaunched = true;
	}

	public void Dead()
	{
		Destroy (gameObject);
	}


}
