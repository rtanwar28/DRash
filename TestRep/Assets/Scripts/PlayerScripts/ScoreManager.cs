using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text currentScoreText;
	int currentScore;
	float timer = 1;

	void Start()
    {
		//if currentPlayerScore is not empty it gets the current Score
		if(PlayerPrefs.GetInt ("CurrentPlayerScore") != 0)
			currentScore = PlayerPrefs.GetInt ("CurrentPlayerScore");
	}
	void Update()
	{
		timer -= Time.deltaTime;

		//Increments the score based on time
		if (timer <= 0) 
		{
			currentScore += 10;
			timer = 1;
		}

		currentScoreText.GetComponent<Text> ().text = currentScore.ToString ();
	}

	// Adds score to the current score
	public void AddScore (int scoreInc)
	{
		currentScore += scoreInc;
	}

	// Gets the score
	public int GetScore()
	{
		return currentScore;
	}
}
