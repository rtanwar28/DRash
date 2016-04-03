using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindObjectOfType<GameManager>().name != null)
            GetComponent<Text>().text = GameObject.FindObjectOfType<GameManager>().name;
    }
}
