using UnityEngine;
using System.Collections;

public class SkullMovement : MonoBehaviour {
	private float moveSpeed;

	// Update is called once per frame
	void Update () 
	{
		moveSpeed = Random.Range (3.5f, 8.5f);
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	}
}
