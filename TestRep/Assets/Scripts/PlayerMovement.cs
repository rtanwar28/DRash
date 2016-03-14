using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed; // Setting the player speed
	
	Animator animator;

	public GameObject fireball;
	public Transform firePoint;
	
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

		//Left Player Movement
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate (Vector2.left * speed * Time.deltaTime);

			animator.SetBool("mLeft",true);
			animator.SetBool("mRight",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mUp",false);
			animator.SetBool("mIdle",false);
		}

		else
		//Right Player Movement
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);

			animator.SetBool("mRight",true);
			animator.SetBool("mLeft",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mUp",false);
			animator.SetBool("mIdle",false);
		}

		else
		//Up Player Movement
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.Translate (Vector2.up * speed * Time.deltaTime);

			animator.SetBool("mUp",true);
			animator.SetBool("mLeft",false);
			animator.SetBool("mRight",false);
			animator.SetBool("mDown",false);
			animator.SetBool("mIdle",false);

		}

		else
		//Down Player Movement
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Translate (Vector2.down * speed * Time.deltaTime);

			animator.SetBool("mDown",true);
			animator.SetBool("mUp",false);
			animator.SetBool("mLeft",false);
			animator.SetBool("mRight",false);
			animator.SetBool("mIdle",false);
		}

		//Idle State
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
		}

	}
}
