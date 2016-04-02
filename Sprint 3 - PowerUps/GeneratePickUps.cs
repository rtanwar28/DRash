using UnityEngine;
using System.Collections;

public class GeneratePickUps : MonoBehaviour {

	public float initialValue;
	float generatePUTimer; // Float variable for timer
	public GameObject[] pickUps = new GameObject[2]; // An array of gameobjects that hold powerup pick-ups

	// Use this for initialization
	void Start () {

		generatePUTimer = initialValue;
	}
	
	// Update is called once per frame
	void Update () 
	{
		generatePUTimer -=Time.deltaTime; // Decreasing the Timer value
		
		if(generatePUTimer <= 0)
		{
			Instantiate(pickUps[Random.Range(0,2)],new Vector3(Random.Range(-6.5f,6.5f),9.5f,0f),Quaternion.identity); // Instantiating the pick-ups
			generatePUTimer = initialValue;
		}	
	}

}
