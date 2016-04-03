using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntryScript : MonoBehaviour {

    public GameObject nameOutText, scoreOutText;
    public string nameOut, scoreOut;

	// Use this for initialization
	void Start ()
    {
        nameOutText.GetComponent<Text>().text = nameOut;
        scoreOutText.GetComponent<Text>().text = scoreOut;
    }


}
