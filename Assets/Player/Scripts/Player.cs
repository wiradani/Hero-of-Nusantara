using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	GameObject predictor;
	public Rigidbody2D rbPredictor;

	public GameObject pointer;
	public Rigidbody2D rbPointer;

	public GameObject bullet;
	//public Rigidbody2D rb;
	public bool isPressed = false;



	// Use this for initialization
	void Start () {
		predictor = GameObject.FindGameObjectWithTag("Predictor");
		rbPredictor = predictor.GetComponent<Rigidbody2D> ();
		rbPredictor.isKinematic = true;

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

	}
		
	public float forceX, forceY, power;
	public bool isLaunched = false;
	void OnMouseUp ()
	{
		isPressed = false;
		rbPredictor.isKinematic = false;
		rbPredictor.gravityScale = 1;
		GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
		CircleCollider2D colObj = obj.GetComponent<CircleCollider2D> ();
		Rigidbody2D rbObj = obj.GetComponent<Rigidbody2D> ();
		forceX = gameObject.transform.position.x - rbPointer.position.x;
		forceY = gameObject.transform.position.y - rbPointer.position.y;
		rbObj.AddForce (new Vector2 (forceX*power, forceY*power));
		//yield return new WaitForSeconds (.5f);
		//colObj.enabled = true;

		isLaunched = true;
		rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
	}

	//IEnumerator Shoot(){
		

	//}

}
