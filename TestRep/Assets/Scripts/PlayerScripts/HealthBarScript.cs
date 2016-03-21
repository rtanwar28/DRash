using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour 
{
	private float fillAmount;
	private float health;


	private float maxHealth;
	public Image content;
	public Text healthText;

	// Use this for initialization
	void Start () 
	{
		maxHealth = gameObject.GetComponent<HealthScript> ().maxHealth;
	}

	// Update is called once per frame
	void Update () 
	{
		health = gameObject.GetComponent<HealthScript> ().health;
		healthText.text = health + "/" + maxHealth;
		HandleHealth ();
	}

	void HandleHealth()
	{
		content.fillAmount = TranslateHealthToFillAmount(health, 0, maxHealth, 0, 1);
	}

	// Makes the value translate from the max health to the fillamount
	float TranslateHealthToFillAmount(float value, float inMin, float inMax, float outMin, float outMax)
	{
		// Changes the health into a scale that is from 0 to 1
		return (value - inMin) * (outMax - outMin)/(inMax - inMin) + outMin;
	}
}
