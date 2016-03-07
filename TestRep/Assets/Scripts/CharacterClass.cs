using UnityEngine;
using System.Collections;

public class CharacterClass : MonoBehaviour {

	int health;
	bool isDead;

	// Default settings
	/*public CharacterClass(int attackDamageCount,int healthStart)
	{
		attackDamage = attackDamageCount;
		health = healthStart;
		isDead = false;
	}*/

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
