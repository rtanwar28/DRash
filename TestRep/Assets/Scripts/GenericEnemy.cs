using UnityEngine;
using System.Collections;

public class GenericEnemy : CharacterClass {

    float timeToTrue = 5;

    GameObject enemyAttack;

    public bool isAbleToDestroy;
    public IEnemyMovement movement;

	public void movementSetter(IEnemyMovement movementInput)
	{
        movement = movementInput;
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
    }

	void FixedUpdate()
	{
        // Moves the enemy
        if (movement == null)
        {
            movement = new LinearMovement();
        }
		movement.Move (gameObject);
	}
}
