using UnityEngine;
using System.Collections;

public class RandomEnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public IEnemyMovement testMovement;
	float timeTilSpawn;
	public int moveSpawnLimitter;
	public float timer;
	public int damage;
    int randomNumber;

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
            //Debug.Log("Line");
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			timeTilSpawn = timer + Random.Range (0, 6);
			break;

		case 2:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new UpDownMovement());
            //Debug.Log("UD");
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			timeTilSpawn = timer + Random.Range(0,6);
			break;

		case 3:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new FollowMovement());
            //Debug.Log("Follow");
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			timeTilSpawn = timer + Random.Range(0,6);
			break;

		case 4:
			enemyC = Instantiate (enemyPrefab, randomPosition, Quaternion.identity)as GameObject;
			enemyC.GetComponent<GenericEnemy> ().movementSetter (new WaveMovement ());
            //Debug.Log("Wave");
			enemyC.GetComponent<GenericEnemy> ().shotDamage = damage;
			timeTilSpawn = timer + Random.Range (0, 6);
			break;
		}

		randomNumber = 0;
	}
}
