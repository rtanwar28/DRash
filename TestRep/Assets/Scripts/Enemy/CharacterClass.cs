using UnityEngine;
using System.Collections;

public class CharacterClass : MonoBehaviour {

	int health;
	bool isDead;

	//Damage function
	public void GetDamaged(int damageCount)
	{
		health -= damageCount;
	}

	//Death Function
	public void Death()
	{
		
	}
}	
