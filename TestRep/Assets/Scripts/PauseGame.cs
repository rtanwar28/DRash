using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Canvas gameCanvas;
	public Canvas pauseCanvas;

	// Use this for initialization
	void Start () {

		//hiding the canvas when scene starts
		pauseCanvas.enabled = false;
	}

	public void Pause (bool isPaused)
	{
		Debug.Log("Pausing: " + isPaused);

		if (isPaused) //IF GAME IS PAUSED
		{
			gameCanvas.GetComponent<GraphicRaycaster>().enabled = false;
			pauseCanvas.enabled = true;

			Time.timeScale = 0;
		}

		else //IF GAME RESUMES
		{
			gameCanvas.GetComponent<GraphicRaycaster>().enabled = true;
			pauseCanvas.enabled = false;

			Time.timeScale = 1;
		}

	}
}