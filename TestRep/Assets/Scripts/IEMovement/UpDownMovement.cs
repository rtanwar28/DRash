using UnityEngine;
using System.Collections;

public class UpDownMovement : IEnemyMovement {

	public void Move(GameObject go)
	{
		// Moves the object up and down while still being able to move down
		go.transform.Translate(new Vector3 (0, Mathf.Sin(Time.time * 3.5f) * 3 * Time.deltaTime, 0));
	}
}
