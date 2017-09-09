using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	GameObject predictor;
	public Rigidbody2D rbPredictor;

	public GameObject pointer;
	public Rigidbody2D rbPointer;
	public SpriteRenderer srPointer;

	public GameObject bullet;
	public GameObject powerBullet;

	public Rigidbody2D rb;
	public bool isPressed = false;

	public GameObject[] predictTrails;

	public int darah=5;

	Animator anim;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.enabled = false;
	}



	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		anim.Play ("Idle");
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
			anim.Play ("Shoot Ketapel");
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
				anim.Play ("Run");
				rb.velocity = new Vector2 (-2f, 0);
			} else if (Input.GetMouseButtonUp (0)) {
				anim.Play ("Idle");
				rb.velocity = new Vector2 (0, 0);
			}
		}

	}

	void OnMouseDown ()
	{
		
		isPressed = true;
		StartCoroutine (Predict ());

	}
		
	public float forceX, forceY, power=250;

	void OnMouseUp ()
	{
		isPressed = false;
		//rbPredictor.isKinematic = false;
		//rbPredictor.gravityScale = 1;
		StopAllCoroutines();
		rbPredictor.isKinematic = true;
		rbPredictor.position = new Vector2 (1000, 1000);
		for (i = 0; i < 9; i++) {
			predictTrail = predictTrails [i];
			predictTrail.transform.position = new Vector2 (1001, 1001);
		}

		StartCoroutine (Shoot ());


		srPointer.enabled = false;
		//rbPointer.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);

	}

	public bool skillActive=false;
	IEnumerator Shoot(){
		SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Player"));
		GameObject obj;
		if(skillActive)
			obj = Instantiate (powerBullet, transform.position, Quaternion.identity);
		else
			obj = Instantiate (bullet, transform.position, Quaternion.identity);
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
		rbPredictor.velocity = new Vector2 (0, 0);
		rbPredictor.AddForce(new Vector2 (forceX*power, forceY*power));
		StartPredictionPath ();
		yield return new WaitForSeconds (1.5f);

		StartCoroutine (Predict ());
	}

	//Predicion Path Making
	int i;
	GameObject predictTrail;
	void StartPredictionPath(){
		StartCoroutine (PathTrailing ());
	}

	IEnumerator PathTrailing(){
		for (i = 0; i < 9; i++) {
			yield return new WaitForSeconds (.2f);
			predictTrail = predictTrails [i];
			predictTrail.transform.position = new Vector2 (rbPredictor.position.x, rbPredictor.position.y);
		}
	}

	void HitDamage(int value){
		darah -= value;
		if (darah <= 0) {
			Destroy (gameObject);
		}
			
	}
}
