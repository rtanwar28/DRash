using UnityEngine;
using System.Collections;

public class DestroyPickUps : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player_Ryu") {
			Destroy (gameObject);
		}

		else

		if (other.gameObject.name == "PowerUpDestroyer" ) {
			Destroy (gameObject);
		}
	}
}
