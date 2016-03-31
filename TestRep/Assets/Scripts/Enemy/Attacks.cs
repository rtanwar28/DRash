using UnityEngine;
using System.Collections;

public class Attacks : MonoBehaviour {

	public float attackSpeed = 1f;
	public float projectileSpeed;
	int attackCount;

	public GameObject shotPrefab;

	public AudioSource audio_fire;

	// Update is called once per frame
	void Update () 
	{
		attackSpeed -= Time.deltaTime;
		attackCount = GetComponentInParent<GenericEnemy> ().shotDamage;
        // calls the function that will instantiate the fireball
		if (attackSpeed <= 0) 
		{
			Fire (shotPrefab, projectileSpeed, attackCount);
			attackSpeed = 1f;
		}
	}

    // Instantiates a fireball
	void Fire(GameObject shot, float speed, int attackDamage)
	{
		GameObject shotClone = Instantiate (shot, transform.position, Quaternion.identity) as GameObject;
		shotClone.GetComponent<ShotClass> ().shotDamage = attackDamage;
		shotClone.GetComponent<ShotClass> ().shotSpeed = speed;

		audio_fire.Play();
	}
}
