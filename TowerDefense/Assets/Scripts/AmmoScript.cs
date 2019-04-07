using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour {
	public TowerConfig towerConfig;
	public static float lifeToDeduct;
	public static float ammoDamage;
	public static Transform ammoTarget;
	public static float ammoSpeed = 30f;

	/// <summary>
	/// The target position of the ammo.
	/// </summary>
	/// <param name="target">Target.</param>
	public virtual void AmmoTarget (Transform target) 
	{
		ammoTarget = target;
	}

	/// <summary>
	/// Launches the ammo to the targeted area (ammoTarget).
	/// </summary>
	/// <param name="_ammoTarget">Ammo target.</param>
	public virtual void MoveTowardsTarget(Transform _ammoTarget)
	{
		if (_ammoTarget == null) 
		{
			Destroy (gameObject);
		} 

		else 
		{
			Vector3 direction = _ammoTarget.position - transform.position;
			transform.Translate (direction.normalized * ammoSpeed * Time.deltaTime, Space.World);
		}
	}

	/// <summary>
	/// Gives the ammo a certain effect to afflict the target (e.g. deal
	/// the target some damage, slow down enemies, etc.).
	/// </summary>
	/// <param name="_enemy">Enemy.</param>
	public virtual void AmmoEffect(Enemy _enemy)
	{
	}
}
