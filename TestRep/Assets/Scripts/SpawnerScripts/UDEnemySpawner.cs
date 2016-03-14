using UnityEngine;
using System.Collections;

public class UDEnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public IEnemyMovement testMovement;
	float timeTilSpawn;
	public float timer;
	public int damage;

	// Use this for initialization
	void Start () 
	{
		timeTilSpawn = timer;
	}

	// Update is called once per frame
	void Update () {

		timeTilSpawn -= Time.deltaTime;

		// Spawns the enemy based on the timer
		if (timeTilSpawn <= 0) 
		{
			GameObject enemyClone = Instantiate (enemyPrefab, this.transform.position, Quaternion.identity)as GameObject;
			enemyClone.GetComponent<GenericEnemy> ().movementSetter (new UpDownMovement());
			//enemyClone.GetComponent<GenericEnemy> ().shotDamage = damage;
			timeTilSpawn = timer + Random.Range(0,6);
		}
	}
}
