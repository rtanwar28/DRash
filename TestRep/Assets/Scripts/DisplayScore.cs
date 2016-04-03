using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindObjectOfType<GameManager>().currentScore != 0)
            GetComponent<Text>().text = "Score: " + GameObject.FindObjectOfType<GameManager>().currentScore;
    }
}
