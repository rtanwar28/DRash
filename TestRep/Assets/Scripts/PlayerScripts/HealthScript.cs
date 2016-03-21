using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{

	public bool isDead;
	public int maxHealth;
	public int health;
	public SpriteRenderer renderer;
	public Color collideColor, normalColor;

	// Use this for initialization
	void Start () 
	{
		isDead = false;
		renderer = GetComponent<SpriteRenderer> ();
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			isDead = true;
			health = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			// Decrements the player health if hit by the enemy
			health -= 1;
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
			health -= obj.GetComponent<ShotClass> ().shotDamage;
			Destroy (obj.gameObject);
			renderer.material.color = collideColor;
			Invoke("ReturnColor", 0.3f);
		}

	}
}
