using UnityEngine;
using System.Collections;

public class Boss3HeadScript : GenericBossEnemy
{
    public AudioClip fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleHealth();

        if (enemyHealth <= maxEnemyHealth / 2)
        {
            fireStateIndex = 1;
        }

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            GameObject fireClone = (GameObject)Instantiate(firePrefab[fireStateIndex], fireSpawnPoint.position, Quaternion.identity);
            aSource.PlayOneShot(fire);
            attackTimer = attackTimerMax;
            fireClone.transform.SetParent(this.gameObject.transform);
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
