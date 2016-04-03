using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreScript : MonoBehaviour {

    List<PlayerInfo> playerScores;
    string filePath;
    public GameObject entryPrefab, panel;

    // Use this for initialization
    void Start ()
    {
        filePath = Application.dataPath + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar;
        playerScores = new List<PlayerInfo>();

        LoadScore();
        Debug.Log(playerScores.Count);
        // Instantiates entry prefabs with set score and name in the panel
        for (int i = 0; i <= 5; i++)
        {
            GameObject entryClone = (GameObject)Instantiate(entryPrefab, transform.position, Quaternion.identity);
            entryClone.GetComponent<EntryScript>().nameOut = playerScores[i].playerName;
            entryClone.GetComponent<EntryScript>().scoreOut = playerScores[i].score.ToString();
            entryClone.transform.SetParent(panel.transform);
        }
	}

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void LoadScore()
    {
        if (!File.Exists(filePath + "gamedata.dat"))
            return;

        // Loads all score that is in the file
        using (Stream stream = File.Open(filePath + "gamedata.dat", FileMode.Open))
        {
            BinaryFormatter bin = new BinaryFormatter();

            var playerInfo = (List<PlayerInfo>)bin.Deserialize(stream);
            foreach (PlayerInfo p in playerInfo)
            {
                playerScores.Add(new PlayerInfo(p.playerName, p.score));
            }
        }
    }

}
