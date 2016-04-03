using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsScript : MonoBehaviour {

    public AudioMixer masterMixer;
    public string mainScreen;

    // Sets the function for the slider to edit the volume
    public void SetSfxVol(float sfxVol)
    {
        masterMixer.SetFloat("sfxVolume", sfxVol);
    }
    public void SetBGVol(float BGVol)
    {
        masterMixer.SetFloat("bGVolume", BGVol);
    }
    public void SetMasterVolume(float masterVol)
    {
        masterMixer.SetFloat("masterVolume", masterVol);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(mainScreen);
    }
}
