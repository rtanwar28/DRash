using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class PlayerInfo {

	public string playerName { get; set; }
	public int score { get; set; }

	//Constructors to store player info
	public PlayerInfo(string name, int scoreInp)
	{
		playerName = name;
		score = scoreInp;
	}
}
