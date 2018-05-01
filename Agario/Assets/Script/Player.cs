using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
	Alive,
	Dead,
}

public class Player : Unit {
	private Vector3 mousePosition;
	private float camZoomChange = 2.5f;
	public float moveSpeed;
	private float moveSpeedChange;
	public GameObject player;
	public Vector3 playerGrowth;
	public PlayerState playerState;
	public ScoreMgr scoreMgr;

	// Use this for initialization
	void Start () {
		moveSpeedChange = 1.5f * Time.deltaTime;
		playerState = PlayerState.Alive;
		playerGrowth = new Vector3 (0.5f, 0.5f, 0.5f);
	}

	// Update is called once per frame
	void Update () {
		switch (playerState)
		{
		case PlayerState.Alive:
			Alive ();
			break;
		case PlayerState.Dead:
			Dead ();
			break;
		}
	}

	void Alive()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);

		ScreenBounds ();

		if (Input.GetKey (KeyCode.KeypadPlus)) 
		{
			player.transform.localScale += playerGrowth*Time.deltaTime;
			Camera.main.orthographicSize += camZoomChange * Time.deltaTime;
			moveSpeed -= moveSpeedChange;
		}

		if (Input.GetKey (KeyCode.KeypadMinus)) 
		{
			player.transform.localScale -= playerGrowth*Time.deltaTime;
			Camera.main.orthographicSize -= camZoomChange * Time.deltaTime;
			moveSpeed += moveSpeedChange;
		}
	}

	void ScreenBounds()
	{
		this.transform.position = new Vector3 (
			Mathf.Clamp(this.transform.position.x, -45.7f, 32.6f),
			Mathf.Clamp(this.transform.position.y, -38.6f, 45.7f),
			this.transform.position.z);
	}

	void OnTriggerEnter(Collider other)
	{
		if (this.transform.localScale.x > other.transform.localScale.x &&
			this.transform.localScale.y > other.transform.localScale.y &&
			this.transform.localScale.z > other.transform.localScale.z)
		{
			Destroy (other.gameObject);
		}

		UnitType type = other.GetComponent<Unit> ()._type;

		switch (type) 
		{
		case UnitType.Food:
			Debug.Log ("Food eaten");
			ScoreMgr.Score += 2;
			player.transform.localScale += playerGrowth * Time.deltaTime;
			Camera.main.orthographicSize += camZoomChange * Time.deltaTime;
			break;

		case UnitType.Enemy:
			Debug.Log ("Enemy eaten");
			ScoreMgr.Score += 5;
			player.transform.localScale += (playerGrowth*2.0f)*Time.deltaTime;
			Camera.main.orthographicSize += camZoomChange * Time.deltaTime;
			break;
		}
	}

	void OnDestroy()
	{
		Application.Quit();
	}

	void Dead()
	{
		Debug.Log ("DEAD!");
		OnDestroy ();
	}
}
