using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{

	public bool isDead, hasBomb, isShielded;
	public float explRadius = 3;
	public int maxHealth, health, explDamage, collisionDamage;
	public SpriteRenderer renderer;
	public Color collideColor, normalColor;
    public GameObject explosionPrefab;
    public GameObject shield;
    public AudioClip getHit, dieSound, powerUp, explode, noMoreShield;

    bool playedDieSound = false;
    AudioSource aSource;

	// Use this for initialization
	void Start () 
	{
		isDead = false;
		renderer = GetComponent<SpriteRenderer> ();
        aSource = GetComponent<AudioSource>();
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // Sets the bool true for other scripts to reference
		if (health <= 0) 
		{
			isDead = true;
			health = 0;
            if (playedDieSound == false) // Plays the death sound
            {
                playedDieSound = true;
                aSource.PlayOneShot(dieSound);
            }
            Debug.Log("I am Dead");
		}

        // Checks if there is a bomb and detonates it
        if (hasBomb)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Explode();
            }
        }
        // Adds the shield to the player
        if (isShielded)
        {
            Invoke("RunOutOfShield", 5f);
        }
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
            // Decrements the player health if hit by the enemy
            GetDamage(collisionDamage);
			renderer.material.color = collideColor;
			Invoke("ReturnColor", 0.1f);
		}
	}
		
	void ReturnColor()
	{
		renderer.material.color = normalColor;
	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		// Decrements the health if hit by the enemy projectile
		if (obj.gameObject.tag == "enemyFireball") 
		{
			GetDamage(obj.GetComponent<ShotClass> ().shotDamage);
			Destroy (obj.gameObject);
			renderer.material.color = collideColor;
            Invoke("ReturnColor", 0.3f);
		}
        // Decrements the health if hit by the enemy laser
        if (obj.gameObject.tag == "enemyLaser")
        {
            GetDamage(obj.GetComponent<LaserScript>().laserDamage);
            renderer.material.color = collideColor;
            Invoke("ReturnColor", 0.3f);
        }
        // Gives the player Exploding powers!
        if (obj.gameObject.tag == "ExpPU")
        {
            hasBomb = true;
            aSource.PlayOneShot(powerUp);
            Destroy(obj.gameObject);
        }
        // Gives Lives
        if (obj.gameObject.tag == "HeartPU")
        {
            health += 5;
            aSource.PlayOneShot(powerUp);

            Destroy(obj.gameObject);
        }

        // Makes the player fire more
        if (obj.gameObject.tag == "MultiPU")
        {
            if (GetComponent<PlayerMovement>().fireIndex != 2)
            {
                aSource.PlayOneShot(powerUp);
                GetComponent<PlayerMovement>().fireIndex++;
            }
            Destroy(obj.gameObject);
        }
        // Makes the player fire faster
        if (obj.gameObject.tag == "RapidPU")
        {
            if (GetComponent<PlayerMovement>().fireSpeedAdjuster <= 20)
            {
                aSource.PlayOneShot(powerUp);
                GetComponent<PlayerMovement>().fireSpeedAdjuster *= 2;
            }
            Destroy(obj.gameObject);
        }
        // Makes the player gain a sheild that lasts a couple of seconds
        if (obj.gameObject.tag == "ShieldPU")
        {
            aSource.PlayOneShot(powerUp);
            isShielded = true;
            shield.SetActive(true);
            Destroy(obj.gameObject);
        }
    }

    // Damages the player
    void GetDamage(int damage)
    {
        if (isShielded == false)
        {
            aSource.PlayOneShot(getHit);

            health -= damage;
        }
    }

    // Creates an explosion and cast a circle to check if any colliders collide
    void Explode()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, explRadius);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        aSource.PlayOneShot(explode);

        foreach (Collider2D c in colls)
        {
            if (c.GetComponent<GenericEnemy>() != null)
            {
                c.GetComponent<GenericEnemy>().enemyHealth -= explDamage;
            }
            else if (c.GetComponent<GenericBossEnemy>() != null)
            {
                c.GetComponent<GenericBossEnemy>().DamageMe(explDamage / 2);
            }
        }
        hasBomb = false;
    }

    // Deactivate the necessary components if the shield has run out
    void RunOutOfShield()
    {
        aSource.PlayOneShot(noMoreShield, 0.2f);

        shield.SetActive(false);
        isShielded = false;
    }
}
