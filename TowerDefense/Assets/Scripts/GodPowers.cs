using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodPowers : MonoBehaviour {
	bool isCoolingDown = false;
	public float waitTime;

	public virtual void Power(bool coolDown)
	{
		isCoolingDown = false;
		coolDown = isCoolingDown;
	}

	public virtual void CoolDown()
	{
		isCoolingDown = true;
		StartCoroutine (StartCooldown (waitTime));
		Debug.Log ("Power is cooling down");
	}

	IEnumerator StartCooldown(float _waitTime)
	{
		yield return new WaitForSeconds (_waitTime);
		isCoolingDown = false;
		Debug.Log ("Cooled down");
	}
}
