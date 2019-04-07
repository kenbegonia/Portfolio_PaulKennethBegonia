using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Tower {
	public TowerConfig towerConfig;
	
	public Cannon(float build, float fire, float dmg):base(build, fire, dmg)
	{
		buildTime = towerConfig.buildTime;
		fireRate = towerConfig.fireRate;
		damage = towerConfig.damage;
	}

	public override void Build (float _buildTime)
	{
		base.Build (_buildTime);
	}

	void Start()
	{
		Build (towerConfig.buildTime);
	}

	public override void FireShots (GameObject _towerTarget, GameObject _ammoToFire, Transform _ammoSpawnPt, TowerType _type)
	{
		base.FireShots (_towerTarget, _ammoToFire, _ammoSpawnPt, _type);
		towerTarget = _towerTarget;
		ammoToFire = _ammoToFire;
		ammoSpawnPt = _ammoSpawnPt;
		towerType = _type;
	}

	public void OnTriggerEnter(Collider other)
	{
		EnemyType type = other.GetComponent<Enemy> ().type;

		if (type != EnemyType.Flying) 
		{
			towerTarget = other.gameObject;
		}

		else towerTarget = null;

        if (towerTarget != null)
        {
            FireShots(towerTarget, ammoToFire, ammoSpawnPt, towerType);
        }
    }

    public void OnTriggerExit(Collider other)
	{
		towerTarget = null;
	}
}
