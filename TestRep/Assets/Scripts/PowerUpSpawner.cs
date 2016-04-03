using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour
{
    private float timer;
    private int randomNumber;

    public float maxTimer;
    public int minRange, maxRange;
    public List<GameObject> powerUps;

    void Start()
    {
        timer = maxTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            randomNumber = Random.Range(minRange, maxRange);
            SpawnPowerUp();
            timer = maxTimer;
        }
    }

    void SpawnPowerUp()
    {
        Vector3 tempPos = new Vector3(Random.Range(-12, 12), 15, 0);
        Instantiate(powerUps[randomNumber], tempPos, Quaternion.identity);
    }

}
