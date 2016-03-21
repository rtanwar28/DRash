using UnityEngine;
using System.Collections;

public class SideMovement: IEnemyMovement {

	public void Move(GameObject go)
	{
		// Moves the object forward
		go.transform.position += new Vector3(-0.02f * Time.deltaTime,0);
	}
}
