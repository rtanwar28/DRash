using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenericBossEnemy : MonoBehaviour {

    float fillAmount;

    SpriteRenderer renderer;

    [SerializeField]
    protected int enemyHealth;
    protected Animator animator;
    protected float attackTimer = 5;
    protected AudioSource aSource;

    public Transform fireSpawnPoint;
    public Color normalColor, collideColor;
    public Image content;
    public int scoreValue;
    public int maxEnemyHealth;
    public int fireStateIndex = 0;
    public float attackTimerMax;
    public float speed = 1;
    public GameObject[] firePrefab;
    public AudioClip getHit, dieSound;

    // Use this for initialization
    void Start ()
    {
        enemyHealth = maxEnemyHealth;
        aSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }
	

    protected void HandleHealth()
    {
        content.fillAmount = TranslateHealthToFillAmount(enemyHealth, 0, maxEnemyHealth, 0, 1);
    }

    // Makes the value translate from the max health to the fillamount
    float TranslateHealthToFillAmount(float value, float inMin, float inMax, float outMin, float outMax)
    {
        // Changes the health into a scale that is from 0 to 1
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DamageMe(1);
            if (enemyHealth == 0)
            {
                aSource.PlayOneShot(dieSound);
                BossDeath();
            }
            renderer.material.color = collideColor;
            Invoke("ReturnColor", 0.3f);
        }
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "fireBall_y")
        {
            DamageMe(1);
            if (enemyHealth == 0)
                BossDeath();
            Destroy(obj.gameObject);
            renderer.material.color = collideColor;
            Invoke("ReturnColor", 0.3f);
        }
    }

    public void DamageMe(int damage)
    {
        aSource.PlayOneShot(getHit);
        enemyHealth -= damage;
    }
    protected void BossDeath()
    {
        Time.timeScale = 0;
        GameObject.FindObjectOfType<UtilityScript>().BossDead = true;
        Debug.Log("Level Won!");
    }

    // Returns the enemy to normal color
    void ReturnColor()
    {
        renderer.material.color = normalColor;
    }
}
