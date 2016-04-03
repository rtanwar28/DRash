using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheatScript : MonoBehaviour {

	public void LoadLevel1()
	{
		SceneManager.LoadScene("Scene1");
	}
	public void LoadLevel2()
	{
		SceneManager.LoadScene("Scene2");
	}
	public void LoadLevel3()
	{
		SceneManager.LoadScene("Scene3");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
