using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss1EnemyScript : GenericBossEnemy
{
    public float enragedSpeed;
    float index;
    public AudioClip fire;

    // Update is called once per frame
    void Update ()
    {
        HandleHealth();
        // Changes the fire based on health
        if (enemyHealth <= 10)
        {
            speed = enragedSpeed;
            fireStateIndex = 1;
            attackTimerMax = 3;
            animator.SetBool("isEnraged", true);
        }

        // Makes it fire
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
            Debug.Log("Level Won!");
        }
	
	}

    void FixedUpdate()
    {
        // makes the Boss move from left to right
        index += Time.deltaTime;
        float x = 10.0f * Mathf.Cos(1.0f * index * speed);
        transform.localPosition = new Vector3(x,7.5f);
    }
}
