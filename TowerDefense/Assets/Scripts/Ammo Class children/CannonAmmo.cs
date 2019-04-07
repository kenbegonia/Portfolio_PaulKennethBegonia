using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAmmo : AmmoScript {
	public override void AmmoTarget (Transform target)
	{
		base.AmmoTarget (target);
	}

	public override void MoveTowardsTarget (Transform _ammoTarget)
	{
		base.MoveTowardsTarget (_ammoTarget);
	}

	// Use this for initialization
	void Start () {
		ammoDamage = towerConfig.damage;
	}
		
	// Update is called once per frame
	void Update () {
		MoveTowardsTarget (ammoTarget);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Cannon has hit something");

		if (other.gameObject != null) 
		{
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();

			enemy.currLife -= ammoDamage;

			Destroy (this.gameObject);

			Debug.Log ("Damage dealt by cannon: " + ammoDamage);
		}
	}

}
