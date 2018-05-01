using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    PlayerStats playerStats;
    EnemyStats enemyStats;
    PlayerStateBehavior playerState;


    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        playerState = GetComponent<PlayerStateBehavior>();
        enemyStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
    }

    void Start()
    {

    }


    void Update()
    {
        LookTarget();

    }

    void StartEffect()
    {

    }

    void DamageTo()
    {
        Damage();
    }

    void StopEffect()
    {

    }

    void Damage()
    {
        if (playerState.attackPoint == null)
        {
            playerState.attackPoint = null;
        }

        Debug.Log("TARGET DAMAGED!");
        RaycastHit hit;
        if (Physics.Raycast(playerState.createRaycast.transform.position, playerState.createRaycast.transform.forward, out hit, 3f))
        {
			if (hit.collider.tag == "Enemy") {
				Debug.Log ("DAMAGE: " + hit.collider.gameObject.GetComponent<EnemyStats> ().currentHealth);
				hit.collider.gameObject.GetComponent<EnemyStats> ().currentHealth -= playerStats.strength;
			}

        }
    }

    void LookTarget()
    {
        if (playerState.currentState == playerState.attackState)
        {
            Vector3 direction = (playerState.attackPoint.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }
}
