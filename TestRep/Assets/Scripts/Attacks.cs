using UnityEngine;
using System.Collections;

public class Attacks : MonoBehaviour {

	public float attackSpeed = 2f;
	public float projectileSpeed;
	int attackCount;

	public GameObject shotPrefab;
	
	// Update is called once per frame
	void Update () 
	{
		attackSpeed -= Time.deltaTime;

        // calls the function that will instantiate the fireball
		if (attackSpeed <= 0) 
		{
			Fire (shotPrefab, projectileSpeed, attackCount);
			attackSpeed = 2f;
		}
	}

    // Instantiates a fireball
	void Fire(GameObject shot, float speed, int attackDamage)
	{
		Instantiate (shot, transform.position, Quaternion.identity);
		shot.GetComponent<ShotClass> ().shotDamage = attackDamage;
		shot.GetComponent<ShotClass> ().shotSpeed = speed;
	}
}
