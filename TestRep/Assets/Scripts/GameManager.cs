using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour 
{

	public Text nameInput;
	public Text testOutName;
    public Image content;
    public GameObject cheatPanel, SpawnerObject, BossObject, Timer;
    public float maxTime;
    public int currentScore;
    public bool isStarting = true;

    PlayerInfo[] highScores;
	List<PlayerInfo> playerScores;
	PlayerInfo currentPlayer;
	GameObject player;
	string filePath;
	string name;

    float timeLeft;
	bool isSaved = false;

	// Use this for initialization
	void Start () 
	{
        timeLeft = maxTime;
		if (name == null && nameInput != null || name == "" && nameInput != null) 
		{
			Time.timeScale = 0;
			PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		} 
		else if (PlayerPrefs.GetInt ("CurrentPlayerScore") != 0) 
		{
			name = PlayerPrefs.GetString ("CurrentPlayerName");
			currentScore = PlayerPrefs.GetInt ("CurrentPlayerScore");
			testOutName.GetComponent<Text>().text = name;
            isStarting = false;
		}
		// Sets the destination of the file
		filePath =  Application.dataPath + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar;
		playerScores = new List<PlayerInfo>();

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
        HandleTime();
        timeLeft -= Time.deltaTime;
		currentScore = player.GetComponent<ScoreManager> ().GetScore ();
		if (player.GetComponent<HealthScript> ().isDead == true && isSaved == false) 
		{
            Save();
		}
		if(player.GetComponent<HealthScript> ().isDead == true && isSaved == true)
		{
			Time.timeScale = 0;
		}

        if (timeLeft <= 0)
        {
            BossFight();
            Timer.SetActive(false);
        }
	}

	public void NameGet()
	{
		PlayerPrefs.SetString ("CurrentPlayerName", nameInput.GetComponent<Text>().text.ToString());
		name = PlayerPrefs.GetString ("CurrentPlayerName");
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		testOutName.GetComponent<Text>().text = name;
        isStarting = false;
		Time.timeScale = 1;
	}

    public void Save()
    {

        // Loads the playerScore List
        LoadScore();
        currentPlayer = new PlayerInfo(name, currentScore);
        // scoreOut.GetComponent<Text>().text = "Score: " + currentScore;
        // nameOut.GetComponent<Text>().text = name;
        playerScores.Add(currentPlayer);

        // Saves the score by descending order and using the SaveToFile function
        playerScores = playerScores.OrderByDescending(x => x.score).ToList();
        SaveScore();
        isDying();
        isSaved = true;
        Debug.Log("Save");
        PlayerPrefs.SetString("CurentPlayerName", "");
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
	void isDying()
	{
		PlayerPrefs.SetString ("CurrentPlayerName", "");
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
	}
	// Saves the new scores to the data file
	void SaveScore()
	{
		// saves a player score
		using (Stream stream = File.Open(filePath+"gamedata.dat", FileMode.Create))
		{
			BinaryFormatter bin = new BinaryFormatter();
			bin.Serialize(stream, playerScores);
			Debug.Log ("Saved");
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
				playerScores.Add (new PlayerInfo (p.playerName, p.score));
			}
		}
	}

    void BossFight()
    {
        SpawnerObject.SetActive(false);
        BossObject.SetActive(true);
    }
    
    void HandleTime()
    {
        content.fillAmount = TranslateHealthToFillAmount(timeLeft, 0, maxTime, 0, 1);
    }

    // Makes the value translate from the max health to the fillamount
    float TranslateHealthToFillAmount(float value, float inMin, float inMax, float outMin, float outMax)
    {
        // Changes the health into a scale that is from 0 to 1
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
