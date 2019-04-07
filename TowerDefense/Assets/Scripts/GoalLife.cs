using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLife : MonoBehaviour {
	public static int Life = 1000;
	private int goalDmg;

	public void OnTriggerEnter(Collider other)
	{
		goalDmg = other.GetComponent<EnemyBehavior>().dmgToGoal;
		Life -= goalDmg;
	}
}
