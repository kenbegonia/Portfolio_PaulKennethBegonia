using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAmmo : AmmoScript {
	public override void AmmoTarget (Transform target)
	{
		base.AmmoTarget (target);
	}

	public override void MoveTowardsTarget (Transform _ammoTarget)
	{
		base.MoveTowardsTarget (_ammoTarget);
	}

	public override void AmmoEffect (Enemy _enemy)
	{
		base.AmmoEffect (_enemy);

		_enemy.currLife -= ammoDamage;
	}

	public void SpeedDebuff(EnemyBehavior _behavior)
	{
		float slowSpd = _behavior.enemyConfig.speed / 2.0f;
		float regSpeed = _behavior.enemyConfig.speed;

		for (float i = 0; i <= 5; i += Time.deltaTime) 
		{
			_behavior.enemyConfig.speed = slowSpd;

			if (i > 5) 
			{
				_behavior.enemyConfig.speed = regSpeed;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Ice tower has hit something");

		if (other.gameObject != null) 
		{
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			EnemyBehavior behavior = other.gameObject.GetComponent<EnemyBehavior> ();

			AmmoEffect (enemy);

			SpeedDebuff (behavior);

			Destroy (this.gameObject);

			Debug.Log ("Damage dealt by ice: " + ammoDamage);
		}
	}
		
	// Use this for initialization
	void Start () 
	{
		ammoDamage = towerConfig.damage;
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveTowardsTarget (ammoTarget);
	}
}
