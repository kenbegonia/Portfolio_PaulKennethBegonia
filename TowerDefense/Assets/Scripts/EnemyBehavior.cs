using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
	public EnemySpawnMgr enemyMgr;
	public Enemy enemy;
	public GameObject target;
	public EnemyConfig enemyConfig;
	public int dmgToGoal;

	[HideInInspector]
	public float moveSpeed;

	private float dmgToLife;
	private NavMeshAgent navAgent;


	void Start()
	{
		moveSpeed = enemyConfig.speed;
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.SetDestination (target.transform.position);
		navAgent.speed = moveSpeed;
		dmgToGoal = enemyConfig.damageToGoal;
	}
}
