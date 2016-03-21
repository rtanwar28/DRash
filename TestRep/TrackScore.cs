using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class TrackScore : MonoBehaviour {
	
	string filePath;

	// Use this for initialization
	void Start () {

	 	filePath = Application.dataPath + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar;
	}
	
	public void InsertLine(string name, int score)
	{
		using (StreamWriter fileWriter=new StreamWriter(filePath+"TrackGameScore.txt",true)) 
		{
			fileWriter.WriteLine("  "+name+"           "+score);
		}
	}
}
