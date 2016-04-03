using UnityEngine;
using System.Collections.Generic;

public class PlayerFireController : MonoBehaviour {

    Transform[] fireChild;
    public float speed;
    
    // Use this for initialization
    void Start () {
        fireChild = GetComponentsInChildren<Transform>();

        foreach (Transform f in fireChild)
        {
            if (f.gameObject.GetComponent<FireballController>() != null)
                f.gameObject.GetComponent<FireballController>().fireSpeed = speed;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
	}
}
