using UnityEngine;
using System.Collections;

public class Boss3BodyScript : MonoBehaviour {

    public float speed = 1;
    float index;

    void FixedUpdate()
    {
        // makes the Boss move from left to right
        index += Time.deltaTime;
        float x = 10.0f * Mathf.Cos(1.0f * index * speed);
        transform.localPosition = new Vector3(x, 4.74f);
    }
}
