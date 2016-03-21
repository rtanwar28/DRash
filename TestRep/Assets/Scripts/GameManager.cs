using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour 
{

	public Text nameInput;

	PlayerInfo[] highScores;
	List<PlayerInfo> playerScores;
	PlayerInfo currentPlayer;
	GameObject player;
	string filePath;
	string name;
	int currentScore;

	// Use this for initialization
	void Start () 
	{
		if (name == null && nameInput != null) 
		{
			Time.timeScale = 0;
			PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		} 
		else if (name != null) 
		{
			currentScore = PlayerPrefs.GetInt ("CurrentPlayerScore");
		}
		// Sets the destination of the file
		filePath =  Application.dataPath + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar;
		playerScores = new List<PlayerInfo>();

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.GetComponent<HealthScript> ().isDead == true) 
		{
			Time.timeScale = 0;

			// Loads the playerScore List
			LoadScore ();
			// currentPlayer = new PlayerInfo (name, scoreCount);
			playerScores.Add (currentPlayer);

			// Saves the score by descending order and using the SaveToFile function
			playerScores = playerScores.OrderByDescending (x => x.score).ToList ();
			SaveScore ();
		}
	}

	public void NameGet()
	{
		PlayerPrefs.SetString ("CurrentPlayerName", nameInput.ToString());
		name = PlayerPrefs.GetString ("CurrentPlayerName");
		Debug.Log (name);
		Time.timeScale = 1;
	}

	// Saves the new scores to the data file
	void SaveScore()
	{
		// saves a player score
		using (Stream stream = File.Open(filePath+"gamedata.dat", FileMode.Create))
		{
			BinaryFormatter bin = new BinaryFormatter();
			bin.Serialize(stream, playerScores);
		}
	}
		
	void LoadScore()
	{
		if (!File.Exists (filePath + "gamedata.dat"))
			return;

		// Loads all score that is in the file
		using (Stream stream = File.Open (filePath + "gamedata.dat", FileMode.Open)) 
		{
			BinaryFormatter bin = new BinaryFormatter ();

			var playerInfo = (List<PlayerInfo>)bin.Deserialize(stream);
			foreach (PlayerInfo p in playerInfo) 
			{
				playerScores.Add (new PlayerInfo(p.playerName, p.score));
			}
		}
	}
}
