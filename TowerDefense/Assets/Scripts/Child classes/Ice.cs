using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Tower {
	public TowerConfig towerConfig;
	private float currTime = 0.0f;
	private float nextFireTime = 5.0f;

	public Ice(float build, float fire, float dmg):base(build, fire, dmg)
	{
		buildTime = towerConfig.buildTime;
		fireRate = towerConfig.fireRate;
		damage = towerConfig.damage;
	}

	public override void FireShots (GameObject _towerTarget, GameObject _ammoToFire, Transform _ammoSpawnPt, TowerType _type)
	{
		base.FireShots (_towerTarget, _ammoToFire, _ammoSpawnPt, _type);
		towerTarget = _towerTarget;
		ammoToFire = _ammoToFire;
		ammoSpawnPt = _ammoSpawnPt;
		towerType = _type;
	}

	void Update()
	{
		currTime += Time.deltaTime;

		if (towerTarget != null && currTime > nextFireTime) 
		{
			currTime -= nextFireTime;

			FireShots (towerTarget, ammoToFire, ammoSpawnPt, towerType);
		}
	}

	public override void Build (float _buildTime)
	{
		base.Build (_buildTime);
	}

	void Start()
	{
		Build (towerConfig.buildTime);
	}

	public void OnTriggerEnter(Collider other)
	{
		towerTarget = other.gameObject;
	}

	public void OnTriggerExit(Collider other)
	{
		towerTarget = null;
	}
}
