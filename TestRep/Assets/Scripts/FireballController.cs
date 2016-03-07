using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	public float fireSpeed; // speed for the fireball
	Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
	
		//Rigidbody 2D component for player fireball
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//rb2D.velocity = new Vector2 (fireSpeed, rb2D.velocity.x);
		rb2D.AddForce (Vector2.up * fireSpeed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Block") {
			Destroy (gameObject);
		}
	}
}
