using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenericEnemy : CharacterClass {

    float timeToTrue = 5;
	float fillAmount;

    GameObject enemyAttack;
	SpriteRenderer renderer;

	public Color normalColor;
	public Color collideColor;
	public Image content;
	public int enemyHealth;
	public int maxEnemyHealth;
    public bool isAbleToDestroy;
    public IEnemyMovement movement;
    public int shotDamage;
	public void movementSetter(IEnemyMovement movementInput)
	{
        movement = movementInput;
	}

	void Start()
	{
		renderer = GetComponent<SpriteRenderer> ();
	}

    void Update()
    {
        // Adds a timer to when the gameobject can be destroyed
        timeToTrue -= Time.deltaTime;
        if (timeToTrue < 0)
            isAbleToDestroy = true;
		
        // Destroys the gameobject
        if (isAbleToDestroy == true && gameObject.GetComponent<SpriteRenderer>().isVisible == false)
        {
            Destroy(gameObject);
        }
		HandleHealth ();

		if (enemyHealth <= 0) 
		{
			Destroy (gameObject);
		}
    }

	void FixedUpdate()
	{
        // Moves the enemy
        if (movement == null)
        {
			movement = new FollowMovement();
			Debug.Log ("wave");
        }
		movement.Move (gameObject);
	}

	void HandleHealth()
	{
		content.fillAmount = TranslateHealthToFillAmount(enemyHealth, 0, maxEnemyHealth, 0, 1);
	}

	// Makes the value translate from the max health to the fillamount
	float TranslateHealthToFillAmount(float value, float inMin, float inMax, float outMin, float outMax)
	{
		// Changes the health into a scale that is from 0 to 1
		return (value - inMin) * (outMax - outMin)/(inMax - inMin) + outMin;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			enemyHealth -= 1;
			renderer.material.color = collideColor;
			Invoke("ReturnColor", 0.3f);
		}
	}
	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "fireBall_y") 
		{
			enemyHealth -= 1;
			Destroy (obj.gameObject);
			renderer.material.color = collideColor;
			Invoke("ReturnColor", 0.3f);
		}
	}

	// Returns the enemy to normal color
	void ReturnColor()
	{
		renderer.material.color = normalColor;
	}
}
