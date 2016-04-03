using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class UtilityScript : MonoBehaviour {

    public Canvas HUD, DeathCanvas, PauseCanvas, WinCanvas;
    public AudioMixerSnapshot paused, unpaused;
    public string nextLevel, mainScreen;
    public bool BossDead;
	
	// Update is called once per frame
	void Update ()
    {
        if (BossDead == true)
        {
            BossIsDead();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (GameObject.FindObjectOfType<HealthScript>().isDead == true)
        {
            PlayerDead();
        }
	}

    void PlayerDead()
    {
        HUD.enabled = false;
        DeathCanvas.gameObject.SetActive(true);
        DeathCanvas.enabled = true;
    }

    void BossIsDead()
    {
        HUD.enabled = false;
        WinCanvas.gameObject.SetActive(true);
        WinCanvas.enabled = true;
    }

    public void PauseGame()
    {
        if (GameObject.FindObjectOfType<GameManager>().isStarting == true)
            return;
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            HUD.enabled = false;
            PauseCanvas.gameObject.SetActive(true);
            PauseCanvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            HUD.gameObject.SetActive(true);
            HUD.enabled = true;

            PauseCanvas.enabled = false;
        }
        LowPass();
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainScreen);
        LowPass();
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        int nextLevelScore = GameObject.FindObjectOfType<GameManager>().currentScore;
        PlayerPrefs.SetInt("CurrentPlayerScore", nextLevelScore);
        SceneManager.LoadScene(nextLevel);
    }

    void LowPass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(0.01f);
        }
        else
        {
            unpaused.TransitionTo(0.01f);
        }
    }
}
