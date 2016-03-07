using UnityEngine;
using System.Collections;

public class LinearMovement : IEnemyMovement {

	public void Move(GameObject go)
	{
		// Moves the object forward
        go.transform.position += new Vector3(0, -0.1f * Time.deltaTime);
	}
}
