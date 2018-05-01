using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
	private float moveSpeed = 4.5f;
	public int Life = 3;
	public int Souls = 0;
	public int soulGoal;
	public int sceneIndex;
	public Text lifeInfo;
	public Text soulNumber;

	void FixedUpdate () 
	{
		lifeInfo.text = "LIVES: " + Life;
		soulNumber.text = "SOULS: " + Souls;

		ScreenBounds ();

		float moveA = Input.GetAxis ("Horizontal");
		float moveB = Input.GetAxis ("Vertical");

		transform.position += new Vector3 (moveA, moveB, 0.0f) * moveSpeed * Time.deltaTime;

		if (Life <= 0) 
		{
			Destroy (this.gameObject);
			SceneManager.LoadScene (11);
		}

		if (Souls >= soulGoal) 
		{
			SceneManager.LoadScene (sceneIndex);
			Debug.Log("Goal reached");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Obstacle") 
		{
			Life--;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Soul") 
		{
			Souls++;
			Destroy (other.gameObject);
		}
	}


	void ScreenBounds()
	{
		this.transform.position = new Vector3 (
			Mathf.Clamp(this.transform.position.x, -10.0f, 10.0f),
			Mathf.Clamp(this.transform.position.y, -4.2f, 0.75f),
			this.transform.position.z);
	}
}
