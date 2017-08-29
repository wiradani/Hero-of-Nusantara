using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	public Rigidbody2D rb;
	public Rigidbody2D hook;
	SpringJoint2D sj2d;
	public float releaseTime = .15f;
	public float maxDragDistance = 2f;


	public bool isPressed = false;

	void Start(){
		sj2d = GetComponent<SpringJoint2D> ();
		sj2d.connectedBody = hook;
		gameObject.transform.position = new Vector2 (hook.transform.position.x,hook.transform.position.y);

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

		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds(2f);

	}
	void Dead(){
		Destroy (gameObject);
	}

}

