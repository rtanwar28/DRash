using UnityEngine;
using System.Collections;

public class UpDownMovement : IEnemyMovement {

	public void Move(GameObject go)
	{
		// Moves the object up and down while still being able to move down
		go.transform.position += new Vector3 (0, Mathf.Sin(Time.time * 7) * 10 * Time.deltaTime, 0);
	}
}
