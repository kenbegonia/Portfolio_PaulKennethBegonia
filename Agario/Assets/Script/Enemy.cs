using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
	Patrol,
	Chase, 
	Eat,
	Run,
	Dead,
}

public class Enemy : Unit {
	private Transform target;
	public GameObject[] toEat;
	public float Distance;
	public EnemyState enemyState = EnemyState.Patrol;
	public Vector3 enemyGrowth = new Vector3 (0.5f, 0.5f, 0.5f);
	private float speed = 5.5f;
	private Vector3 randTarget;

	// Update is called once per frame
	void Update () {
		ScreenBounds ();

		switch (enemyState) {
		case EnemyState.Patrol:
			Patrol ();
			break;
		case EnemyState.Chase:
			Chase ();
			break;
		case EnemyState.Eat:
			Eat ();
			break;
		case EnemyState.Run:
			Run ();
			break;
		case EnemyState.Dead:
			Dead ();
			break;
		}

		RaycastHit hit = new RaycastHit ();
		Physics.SphereCast (transform.position, Distance, transform.up, out hit);

		if (hit.collider != null) 
		{
			target = hit.collider.transform;
			Debug.Log (hit.collider.GetComponent<Unit>()._type);
		}		
	}

	void Patrol()
	{
		if (Vector3.Distance (this.transform.position, randTarget) < 2)
		{
			float posX = Random.Range (-45.7f, 32.6f);
			float posY = Random.Range (-38.6f, 45.7f);
			randTarget = new Vector3 (posX, posY, 0);
		}

		transform.LookAt (randTarget);

		transform.Translate (Vector3.forward * Time.deltaTime * speed);

		if (target && target != null)
		{
			enemyState = EnemyState.Chase;

			if (this.transform.localScale.x < target.transform.localScale.x &&
				this.transform.localScale.y < target.transform.localScale.y &&
				this.transform.localScale.z < target.transform.localScale.z)

			{
				enemyState = EnemyState.Run;
			}
		}
	}

	void Chase()
	{
		if (target != null) 
		{
			transform.LookAt (target.transform.position);

			if (Vector3.Distance (this.transform.position, target.position) > 10) 
			{
				target = null;
				enemyState = EnemyState.Patrol;
			} 

			else 
			{
				//transform.Translate (Vector3.forward * Time.deltaTime * speed);
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
			}
		}
	}

	void Eat()
	{
		enemyState = EnemyState.Patrol;
	}

	void Run()
	{
		if (Vector3.Distance (this.transform.position, target.position) < 10) 
		{
			transform.position = Vector3.MoveTowards(transform.position, transform.position + target.transform.position, speed * Time.deltaTime);
		} 

		enemyState = EnemyState.Patrol;
	}

	void Dead()
	{
		OnDestroy ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (this.transform.localScale.x > other.transform.localScale.x &&
			this.transform.localScale.y > other.transform.localScale.y &&
			this.transform.localScale.z > other.transform.localScale.z){
			Destroy (other.gameObject);
		}

		transform.localScale += enemyGrowth * Time.deltaTime;
	}

	void ScreenBounds()
	{
		this.transform.position = new Vector3 (
			Mathf.Clamp(this.transform.position.x, -45.7f, 32.6f),
			Mathf.Clamp(this.transform.position.y, -38.6f, 45.7f),
			this.transform.position.z);
	}

	void OnDestroy()
	{
		Debug.Log ("Enemy dead");
	}
}
