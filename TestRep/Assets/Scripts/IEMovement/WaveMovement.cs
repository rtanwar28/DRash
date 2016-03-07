using UnityEngine;
using System.Collections;

public class WaveMovement : IEnemyMovement {

	public void Move(GameObject go)
	{
		// Makes a wave movement forward 
		go.transform.position += new Vector3 (Mathf.Sin(Time.time * 5) * 20 * Time.deltaTime, 0.01f, 0);
	}
}
