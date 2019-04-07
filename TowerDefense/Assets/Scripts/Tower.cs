using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
	Arrow,
	Cannon,
	Fire,
	Ice,
}

public class Tower : MonoBehaviour {
	public GameObject ammoToFire;
	public Transform ammoSpawnPt;
	public TowerType towerType;
	[HideInInspector]
	public GameObject towerTarget;
	bool isBuilding = true;
    private bool isShooting;
	protected float buildTime, fireRate, damage;

	public Tower(float build, float fire, float dmg)
	{
		buildTime = build;
		fireRate = fire;
		damage = dmg;
	}

	public virtual void Build(float _buildTime)
	{
		isBuilding = true;
        isShooting = false;
		StartCoroutine (StartBuild (_buildTime));
		Debug.Log (towerType + " is building | Build time: " + _buildTime + " seconds");
	}

	IEnumerator StartBuild(float _waitTime)
	{
		yield return new WaitForSeconds (_waitTime);
		isBuilding = false;
		Debug.Log (towerType + " is built");
	}

    void StopFiring()
    {
        isShooting = false;
        Debug.Log("Firing has restarted");
    }

	public virtual void FireShots (GameObject _towerTarget, GameObject _ammoToFire, Transform _ammoSpawnPt, TowerType _type)
	{
		if (isBuilding == false){
			transform.LookAt (_towerTarget.transform.position);

			GameObject ammoSpawn = (GameObject)Instantiate (_ammoToFire, 
				_ammoSpawnPt.position, _ammoSpawnPt.rotation); 

			AmmoScript ammo = ammoSpawn.GetComponent<AmmoScript> ();
			ammo.AmmoTarget (_towerTarget.transform);
			Destroy (ammoSpawn, 5.0f);

			Debug.Log (_type + " tower is firing...");

            if (!isShooting){
                isShooting = true;
                Invoke("StopFiring", fireRate);
            }
        }
	}
}
