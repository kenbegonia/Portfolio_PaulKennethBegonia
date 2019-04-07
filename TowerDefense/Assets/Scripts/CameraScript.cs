using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private float moveSpeed = 9.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CameraBounds ();

		if (Input.GetKey (KeyCode.LeftArrow) || Input.mousePosition.x < 15) 
		{
			this.transform.position += Vector3.left*moveSpeed*Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.mousePosition.x > Screen.width - 15) 
		{
			this.transform.position += Vector3.right*moveSpeed*Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.mousePosition.y > Screen.height - 15) 
		{
			this.transform.position += Vector3.forward*moveSpeed*Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.mousePosition.y < 15) 
		{
			this.transform.position += Vector3.back*moveSpeed*Time.deltaTime;
		}
	}

	void CameraBounds()
	{
		this.transform.position = new Vector3 (
			Mathf.Clamp (this.transform.position.x, 0.0f, 63.0f),
			this.transform.position.y,
			Mathf.Clamp (this.transform.position.z, 0.0f, 63.0f));
	}
}
