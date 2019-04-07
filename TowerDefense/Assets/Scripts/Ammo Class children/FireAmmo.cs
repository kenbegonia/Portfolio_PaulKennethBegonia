using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAmmo : AmmoScript {
	
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
		//_enemy.currLife -= ammoDamage * Time.deltaTime;
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
		Debug.Log ("Fireball has hit something");

		if (other.gameObject != null){
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
            AmmoEffect (enemy);
            Debug.Log ("Damage dealt by fireball: " + ammoDamage);
		}
	}
}
