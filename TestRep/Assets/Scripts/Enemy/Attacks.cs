using UnityEngine;
using System.Collections;

public class Attacks : MonoBehaviour {

	public float attackSpeed = 1f;
	public float projectileSpeed;
    public AudioClip fireSound;
    public GameObject shotPrefab;

    AudioSource aSource;
    int attackCount;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () 
	{
		attackSpeed -= Time.deltaTime;
		attackCount = GetComponentInParent<GenericEnemy> ().shotDamage;
        // calls the function that will instantiate the fireball
		if (attackSpeed <= 0) 
		{
			Fire (shotPrefab, projectileSpeed, attackCount);
            aSource.PlayOneShot(fireSound);
			attackSpeed = 1f;
		}
	}

    // Instantiates a fireball
	void Fire(GameObject shot, float speed, int attackDamage)
	{
		GameObject shotClone = Instantiate (shot, transform.position, Quaternion.identity) as GameObject;
		shotClone.GetComponent<ShotClass> ().shotDamage = attackDamage;
		shotClone.GetComponent<ShotClass> ().shotSpeed = speed;
	}
}
