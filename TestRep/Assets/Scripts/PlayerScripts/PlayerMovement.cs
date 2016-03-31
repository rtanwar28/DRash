using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed; // Setting the player speed
	
	Animator animator;

	public GameObject fireball;
	public Transform firePoint;
	public AudioSource playerFire;
	
	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		Vector2 temp = transform.position;
		//Clamping the player to the x-axis
		temp.x = Mathf.Clamp (transform.position.x, -12, 12);

		//Clamping the player to the y-axis
		temp.y = Mathf.Clamp (transform.position.y, -8, 8);

		// Setting the player position to the clamped values along the x and the y axis.
		transform.position = temp;
	}
	

	void FixedUpdate()
	{
		// Moves the player if a button is pressed
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
		{
			transform.Translate (Vector2.left * speed * Time.deltaTime);

			animator.SetBool("mLeft",true);
			animator.SetBool("mRight",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mUp",false);
			animator.SetBool("mIdle",false);
		}
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);

			animator.SetBool("mRight",true);
			animator.SetBool("mLeft",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mUp",false);
			animator.SetBool("mIdle",false);
		}
		else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
		{
			transform.Translate (Vector2.up * speed * Time.deltaTime);

			animator.SetBool("mUp",true);
			animator.SetBool("mLeft",false);
			animator.SetBool("mRight",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mIdle",false);

		}

		else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
		{
			transform.Translate (Vector2.down * speed * Time.deltaTime);

			animator.SetBool("mDown",true);
			animator.SetBool("mUp",false);
			animator.SetBool("mLeft",false);
			animator.SetBool("mRight",false);
			animator.SetBool("mIdle",false);
		}
		else 
		{
			animator.SetBool("mIdle",true);
			animator.SetBool("mLeft",false);
			animator.SetBool("mRight",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mUp",false);
		}

		//Instantiating player fireballs
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Instantiate(fireball,firePoint.position, firePoint.rotation);
			playerFire.Play();
		}

	}
}
