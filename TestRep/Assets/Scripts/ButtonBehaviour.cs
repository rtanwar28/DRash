using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
		Application.LoadLevel("HowToPlay");
	}
	

	public void PlayGame()
	{
		Application.LoadLevel("Scene1");
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
	
	
	
	//FOR SETTINGS BUTTON
	
	public void SettingsButtonEnter() 
	{
		settingsFire.enabled = true;
	}
	
	public void SettingsButtonExit()
	{
		settingsFire.enabled = false;
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
		Application.LoadLevel("Quit");
	}
}
