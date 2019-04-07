using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoalDetection : MonoBehaviour {
	public EnemySpawnMgr enemyMgr;

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);

		EnemyType type = other.GetComponent<Enemy> ().type;

		switch (type) 
		{
		case EnemyType.Ground:
			Debug.Log ("Ground monster has reached goal");
				break;

		case EnemyType.Flying:
			Debug.Log ("Flying monster has reached goal");
				break;

		case EnemyType.Boss:
			Debug.Log ("Boss has reached goal");
				break;
		}
	}
}
