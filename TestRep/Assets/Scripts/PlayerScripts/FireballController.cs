using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	public float fireSpeed;
    public bool isAbleToDestroy;
    public AudioClip fireAtStart;

    [SerializeField]
    private float adjuster;
    float timeToTrue = 5;
    Rigidbody2D rb2D;
    AudioSource aSource;
    // Use this for initialization
    void Start ()
    {
        aSource = GetComponent<AudioSource>();
		//Rigidbody 2D component for player fireball
		rb2D = GetComponent<Rigidbody2D> ();

        aSource.PlayOneShot(fireAtStart);
	}
	
	// Update is called once per frame
	void Update () {

        // Destroys the gameobject if it is not seen anymore
        timeToTrue -= Time.deltaTime;
        if (timeToTrue < 0)
            isAbleToDestroy = true;
        if (isAbleToDestroy == true && gameObject.GetComponent<SpriteRenderer>().isVisible == false)
        {
            Destroy(gameObject);
        }

        //rb2D.velocity = new Vector2 (fireSpeed, rb2D.velocity.x);
        
	}

	void FixedUpdate()
	{
		rb2D.AddForce (new Vector2(adjuster, fireSpeed), ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Block") {
			Destroy (gameObject);
		}
	}
}
