using UnityEngine;
using System.Collections;

public class FollowMovement : IEnemyMovement 
{
	// MUST HAVE PLAYER TAGGED ON THE SCENE
	public GameObject player;

	public void Move(GameObject go)
	{
		// Sets the speed and finds the player
		float speed = 10;
		player = GameObject.FindGameObjectWithTag ("Player");

		// Sets the players position
		Vector3 playerPosition = player.transform.position;
		// Sets this objects position
		Vector3 enemyPosition = go.transform.position;

		// Checks wether the object is near the player
		if (Vector3.Distance (enemyPosition, playerPosition) > 5f) 
		{
			Vector3 direction = playerPosition - enemyPosition;

			//Normalizes the value
			direction.Normalize ();

			// moves the object towards the player
			go.transform.Translate (direction * speed * Time.deltaTime, Space.World);
		}
		else // In case the object is not near
		{
			// Moves the object forward
			go.transform.position += new Vector3(0, -0.1f * Time.deltaTime);
		}
	}
}
