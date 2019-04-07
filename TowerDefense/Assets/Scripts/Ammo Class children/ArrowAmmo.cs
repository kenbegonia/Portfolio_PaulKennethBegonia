using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAmmo : AmmoScript {

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

	/// Use this for initialization
	void Start () 
	{
		ammoDamage = towerConfig.damage;
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveTowardsTarget (ammoTarget);
	}
		
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Arrow has hit something");

		if (other.gameObject != null) {
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
            AmmoEffect (enemy);
            Destroy (this.gameObject);
            Debug.Log ("Damage dealt by arrow: " + ammoDamage);
		}
	}
}
