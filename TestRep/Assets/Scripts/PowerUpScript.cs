using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour
{
    bool isAbleToDestroy = false;
    float timer = 5;
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(0, -15f * Time.deltaTime));
        timer -= Time.deltaTime;
        if (timer <= 0)
            isAbleToDestroy = true;
        if (isAbleToDestroy == true && gameObject.GetComponentInChildren<SpriteRenderer>().isVisible == false)
        {
            Destroy(gameObject);
        }

    }
}
