using UnityEngine;
using System.Collections;

public class RandomEnemySpawner : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public IEnemyMovement testMovement;

	public int moveSpawnLimitter;
	public float timer;
	public int damage;
	public int enemyHealthSpawn;

    int randomNumber;
	float timeTilSpawn;
    GameObject enemyC;

	// Use this for initialization
	void Start () {
		timeTilSpawn = timer;
	}

	// Update is called once per frame
	void Update () {

		timeTilSpawn -= Time.deltaTime;

		// Spawns the enemy based on the timer
		if (timeTilSpawn <= 0) 
		{
			
			timeTilSpawn = timer;
            if(randomNumber == 0)
                randomNumber = Random.Range(1, moveSpawnLimitter);
            isSpawn(randomNumber);
            //Debug.Log(randomNumber);
		}
	}

	//Spawns enemy with random movements
	void isSpawn(int number)
	{
        int isCase = number;
        Vector3 randomPosition = new Vector3(Random.Range(-12.0f, 12.0f), this.transform.position.y, 0.0f);
		switch (isCase) 
		{
		case 1:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new LinearMovement ());
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			enemyC.GetComponent<GenericEnemy> ().enemyHealth = enemyHealthSpawn;
			enemyC.GetComponent<GenericEnemy> ().maxEnemyHealth = enemyHealthSpawn;
			timeTilSpawn = timer + Random.Range (0, 6);
			break;

		case 2:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new UpDownMovement());
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			enemyC.GetComponent<GenericEnemy> ().enemyHealth = enemyHealthSpawn;
			enemyC.GetComponent<GenericEnemy> ().maxEnemyHealth = enemyHealthSpawn;
			timeTilSpawn = timer + Random.Range(0,6);
			break;

		case 3:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new FollowMovement());
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			enemyC.GetComponent<GenericEnemy> ().enemyHealth = enemyHealthSpawn;
			enemyC.GetComponent<GenericEnemy> ().maxEnemyHealth = enemyHealthSpawn;
			timeTilSpawn = timer + Random.Range(0,6);
			break;

		case 4:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new SideMovement());
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			enemyC.GetComponent<GenericEnemy> ().enemyHealth = enemyHealthSpawn;
			enemyC.GetComponent<GenericEnemy> ().maxEnemyHealth = enemyHealthSpawn;
			timeTilSpawn = timer + Random.Range(0,6);
			break;

		case 5:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new WaveMovement ());
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			enemyC.GetComponent<GenericEnemy> ().enemyHealth = enemyHealthSpawn;
			enemyC.GetComponent<GenericEnemy> ().maxEnemyHealth = enemyHealthSpawn;
			timeTilSpawn = timer + Random.Range (0, 6);
			break;
		}

		randomNumber = 0;
	}


}
