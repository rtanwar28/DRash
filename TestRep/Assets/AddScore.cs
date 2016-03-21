using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {

	public int playerScore; // to track player score
	
	PlayerInfo playerInfoObj; 

	// Use this for initialization
	void Start () {
		playerInfoObj = GetComponent<PlayerInfo> ();

		playerScore = 0;
		Debug.Log ("In Start() - Player Score: " + playerScore);
	}

	void FixedUpdate () {
	
		//If the 'S' key is pressed then the score is update by 10
		if (Input.GetKeyDown (KeyCode.S)) {
			playerScore += 10;
			Debug.Log ("In FixedUpdate() - Player Score: " + playerScore);
		} 
		else

		//If the 'Q' key pressed the player exits from the application
			if (Input.GetKeyDown (KeyCode.Q)) 
		{
			Debug.Log("Player Dead and Quit");
			Application.Quit();
			//Debug.Log ("Total Score: "+playerScore);
			playerInfoObj.GetScore(playerScore);

		}
	}
}
