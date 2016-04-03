using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInfoPT : MonoBehaviour {

	public InputField iField; // variable for input field
	string pName;

	TrackScore trackObj;

	List<string> nameList = new List<string>();
	List<int> scoreList=new List<int>();

	// Use this for initialization
	void Start () {

		trackObj = GetComponent<TrackScore> ();

		//ReadPlayerName ();
	}

	public void ReadPlayerName()
	{
		pName = iField.text; 
		Debug.Log ("Player Name: " + pName);
	}

	public void GetScore(int score)
	{
		//Debug.Log ("Score Passed: "+score);
		int pScore = score;
		//Debug.Log ("Score Assigned: " + pScore);
		PlayerData (pName, pScore);
	}

	void PlayerData (string playerName,int playerScore)
	{
		//Debug.Log ("Player Name: "+playerName); //Displaying the player name in the console
		Debug.Log ("Player Name: " + playerName + " Score: " + playerScore);
		nameList.Add (playerName);
		scoreList.Add (playerScore);
		scoreList.Sort ();
		PlayerPrefs.Save ();
		trackObj.InsertLine (playerName, playerScore);
	}


	
	
	
}
