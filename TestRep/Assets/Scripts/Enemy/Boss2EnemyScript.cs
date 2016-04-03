using UnityEngine;
using System.Collections;

public class Boss2EnemyScript : GenericBossEnemy
{
    public float rebirthSpeed;
    float index;
    public AudioClip[] fire;

    // Update is called once per frame
    void Update ()
    {
        HandleHealth();
        if (enemyHealth <= maxEnemyHealth / 2)
        {
            fireStateIndex = 1;
            attackTimerMax = 3;
            animator.SetBool("EggMode", true);
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("RebirthMode", 2.0f);


        }

        // Makes it fire
        if (animator.GetBool("EggMode") != true)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                GameObject fireClone = (GameObject)Instantiate(firePrefab[fireStateIndex], fireSpawnPoint.position, Quaternion.identity);
                aSource.PlayOneShot(fire[fireStateIndex]);
                attackTimer = attackTimerMax;
                fireClone.transform.SetParent(this.gameObject.transform);
            }

            if (enemyHealth <= 0)
            {
                BossDeath();
            }
        }
    }

    void RebirthMode()
    {
        speed = rebirthSpeed;
        GetComponent<BoxCollider2D>().enabled = true;
        animator.SetBool("EggMode", false);
        animator.SetBool("RebirthMode", true);
    }

    void FixedUpdate()
    {
        if (animator.GetBool("EggMode") != true)
        {
            // makes the Boss move from left to right
            index += Time.deltaTime;
            float x = 10.0f * Mathf.Cos(1.0f * index * speed);
            transform.localPosition = new Vector3(x, 7.5f);
        }
    }
}
