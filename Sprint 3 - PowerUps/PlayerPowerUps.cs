using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour {

	public float powerUpTimer; // Timer for how long the power up will instantiate

	public GameObject fireball; // for normal fireball prefab
	public Transform firePoint; 

	public GameObject attackSpeedObj; // for speed fireball prefab
	
	public GameObject multipleShots; // for multiple fireball prefab
	public Transform[] multiplePoint= new Transform[3];
	public bool mbool = true;

	int states;

	// Use this for initialization
	void Start () 
	{
		states = 0;
	}

	void FixedUpdate()
	{
		// For Instantiating normal fireballs
		if(states == 0)
		{

			if(Input.GetKeyDown (KeyCode.Space))
			{
				GameObject fireBallObj = (GameObject) Instantiate(fireball,firePoint.position,Quaternion.identity);
			}
		}
		else
		
		// For Instantiating PowerUp : Speed fireballs
			if(states == 1)
		{
			if(Input.GetKeyDown (KeyCode.Space))
			{
			GameObject attackObj = (GameObject) Instantiate(attackSpeedObj,firePoint.position,Quaternion.identity);
			StartCoroutine(PowerUpTimer());
			}
		}
		else

		// For Instantiating PowerUp : Multiple Fireballs
		if(states == 2)
		{
			if(Input.GetKeyDown (KeyCode.Space) && mbool == true)
			{
				for(int i = 0; i<3;i++)
				{
					GameObject mShots = (GameObject) Instantiate (multipleShots,multiplePoint[i].position,Quaternion.identity);
					mbool = false;
		
					StartCoroutine(MultipleTimer());
					StartCoroutine(PowerUpTimer());
				}
			}
		}
	}

	// Helps to generate multiple power shots after a certain (after pressing space bar), so when instantiated the prefabs do not overlap making it look messy
	IEnumerator MultipleTimer()
	{
		if(mbool == false)
		{
			float t = 0.5f;
		yield return new WaitForSeconds(t);
			mbool = true;
		}
	}

	// Setting the power up timer for each power up. Once the timer is over, its state value will change to 0 (i.e. the original fireball).
	IEnumerator PowerUpTimer()
	{
		yield return new WaitForSeconds(powerUpTimer);
		states = 0;
	}

	// Checks which power up the player has hit.
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "PowerUp_1")
		{
			states = 1;
		}
		else
		if(other.gameObject.tag == "PowerUp_2")
		{
			states = 2;
		}
	}

}


