using UnityEngine;
using System.Collections;

public class ShotClass : MonoBehaviour {

	public int shotDamage;
	public float shotSpeed;

	void FixedUpdate()
	{
        // Push the object forward
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, -shotSpeed*Time.deltaTime*500));
        //Debug.Log ("Fire");

        // Destroys this game object if it is not seen in the screeen
        if (gameObject.GetComponent<SpriteRenderer>().isVisible == false)
        {
            Destroy(gameObject);
        }

        // Destroys the gameobject with a timer
		float timeCheck = 10;
		timeCheck -= Time.deltaTime;

		if (timeCheck <= 0) 
		{
			Destroy (gameObject);
		}
	}

}
