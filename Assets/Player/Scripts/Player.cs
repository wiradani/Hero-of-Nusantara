using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	GameObject predictor;
	public Rigidbody2D rbPredictor;

	public GameObject pointer;
	public Rigidbody2D rbPointer;
	public SpriteRenderer srPointer;

	public GameObject bullet;
	public Rigidbody2D rb;
	public bool isPressed = false;





	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		predictor = GameObject.FindGameObjectWithTag("Predictor");
		rbPredictor = predictor.GetComponent<Rigidbody2D> ();
		rbPredictor.isKinematic = true;

		pointer = GameObject.FindGameObjectWithTag ("Pointer");
		rbPointer = pointer.GetComponent<Rigidbody2D> ();
		srPointer = pointer.GetComponent<SpriteRenderer> ();
		srPointer.enabled = false;
		//rb = GetComponent<Rigidbody2D> ();
	}


	public float maxDragDistance = 2f;

	// Update is called once per frame
	void Update () {

		if (isPressed) {
			srPointer.enabled = true;
			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 newMousePos;
			var titik = Vector3.Distance (mousePos, gameObject.transform.position);
			/*if (mousePos.x <= gameObject.transform.position.x) {
				rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);*/
			if (mousePos.x > gameObject.transform.position.x) {
				newMousePos = new Vector2 (gameObject.transform.position.x, mousePos.y);
				titik = Vector3.Distance (newMousePos, gameObject.transform.position);
				if (titik > maxDragDistance) {
					rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y) + (newMousePos - new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y)).normalized * maxDragDistance;
				} else
					rbPointer.position = newMousePos;
			} else {
				if (titik > maxDragDistance) {
					rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y) + (mousePos - new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y)).normalized * maxDragDistance;
				} else
					rbPointer.position = mousePos;
			}

			/*} else {
				rbPointer.position = new Vector2 (gameObject.transform.position.x, mousePos.y);
				if (titik > maxDragDistance)
					rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y) + (mousePos - new Vector2 (gameObject.transform.position.x, mousePos.y)).normalized * maxDragDistance;
				else
					rbPointer.position = mousePos;
			}*/
		} else {
			if (Input.GetMouseButton (0)) {
				rb.velocity = new Vector2 (-2f, 0);
			}else if(Input.GetMouseButtonUp(0))
				rb.velocity = new Vector2 (0, 0);
		}

	}

	void OnMouseDown ()
	{
		
		isPressed = true;
		StartCoroutine (Predict ());

	}
		
	public float forceX, forceY, power;

	void OnMouseUp ()
	{
		isPressed = false;
		//rbPredictor.isKinematic = false;
		//rbPredictor.gravityScale = 1;
		StopCoroutine(Predict());
		rbPredictor.isKinematic = true;
		rbPredictor.position = new Vector2 (1000, 1000);

		StartCoroutine (Shoot ());


		srPointer.enabled = false;
		//rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);

	}

	IEnumerator Shoot(){
		GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
		CircleCollider2D colObj = obj.GetComponent<CircleCollider2D> ();
		Rigidbody2D rbObj = obj.GetComponent<Rigidbody2D> ();
		forceX = gameObject.transform.position.x - rbPointer.position.x;
		forceY = gameObject.transform.position.y - rbPointer.position.y;
		rbObj.AddForce (new Vector2 (forceX*power, forceY*power));
		yield return new WaitForSeconds (.5f);
		colObj.enabled = true;

	}

	IEnumerator Predict(){
		yield return new WaitForSeconds (.5f);
		rbPredictor.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		forceX = gameObject.transform.position.x - rbPointer.position.x;
		forceY = gameObject.transform.position.y - rbPointer.position.y;
		if (rbPredictor.isKinematic) {
			rbPredictor.isKinematic = false;
			rbPredictor.gravityScale = 1;
		}
		rbPredictor.AddForce(new Vector2 (forceX*power, forceY*power));
		yield return new WaitForSeconds (1f);
		StartCoroutine (Predict ());
	}

}
