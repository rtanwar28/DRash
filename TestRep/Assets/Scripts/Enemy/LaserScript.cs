using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    public GameObject Laser;
    public int laserDamage = 5;
    float timer = 5;
    float x = 2;
    float y = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        y += Time.deltaTime * 50;
        timer -= Time.deltaTime;
        if(y >= 20)
        {
            y = 20;
        }
        if (timer > 0)
        {
            Laser.transform.localScale = new Vector3(x, y);
        }
        else if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
