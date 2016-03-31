using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {
	
	public Image startFire;
	public Image settingsFire;
	public Image highscoreFire;
	public Image creditsFire;
	public Image quitFire;
	
	
	// Use this for initialization
	void Start ()
	{
		//starts as not active...as the game starts, fireSprite wont be visible
		startFire.enabled = false; 
		settingsFire.enabled = false;
		highscoreFire.enabled = false; 
		creditsFire.enabled = false; 
		quitFire.enabled = false;
		
	}
	
	//FOR START BUTTON
	
	//if the mouse is in the button box, the fireSprite will appear
	public void StartButtonEnter() 	
	{
		startFire.enabled = true;
	}
	
	//if the mouse is not in the button box, the fireSprite wont be visible
	public void StartButtonExit()
	{
		startFire.enabled = false;
	}
	
	//load the level when start is clicked
	public void StartButtonClick()
	{
		SceneManager.LoadScene("HowToPlay");
		//Application.LoadLevel("HowToPlay");
	}
	


	//LOAD THE GAME FROM THE SCENE "HowToPlay"
	public void PlayGame()
	{
		SceneManager.LoadScene("Scene1");
		//Application.LoadLevel("Scene1");
	}



	//FOR HIGHSCORE BUTTON
	
	public void HighScoreButtonEnter() 
	{
		highscoreFire.enabled = true;
	}
	
	public void HighScoreButtonExit()
	{
		highscoreFire.enabled = false;
	}

	public void HighScoreButtonClick()
	{
		SceneManager.LoadScene("");
	}
	
	
	//FOR SETTINGS BUTTON
	
	public void SettingsButtonEnter() 
	{
		settingsFire.enabled = true;
	}
	
	public void SettingsButtonExit()
	{
		settingsFire.enabled = false;
	}

	public void SettingsButtonClick()
	{
		SceneManager.LoadScene("Settings");
	}
	
	
	
	//FOR CREDITS BUTTON 
	
	public void CreditsButtonEnter() 
	{
		creditsFire.enabled = true;
	}
	
	public void CreditsButtonExit()
	{
		creditsFire.enabled = false;
	}

	public void CreditssButtonClick()
	{
		SceneManager.LoadScene("Credits");
	}
	
	
	
	//FOR QUIT BUTTON
	
	public void QuitButtonEnter()
	{
		quitFire.enabled = true;
	}
	
	public void QuitButtonExit()
	{
		quitFire.enabled = false;
	}
	
	public void QuitButtonClick()
	{
		//end game in the Unity Editor
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;

		//end game in the built application
		#else 
		Application.Quit();
		#endif

	}


	//GOING BACK TO MAIN MENU
	public void BackToMenu()
	{
		SceneManager.LoadScene("MainMenu");
		//Application.LoadLevel("MainMenu");
	}
}
