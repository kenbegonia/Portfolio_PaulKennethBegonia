using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBasicScript : MonoBehaviour {

    public Transform player;
    public List<GameObject> DestinationPoints;
    public float speed;
    public float alertDistance;
    public float walkingDistance;
    public float attackingDistance;
    public float remainingDistance;
    public int minTime;
    public int maxTime;
    private int selectedDestination;
    private NavMeshAgent agent;
    Animator animator;
    private Vector3 direction;
    public MeshRenderer meshRendererFlag;

	private EnemyStats enemyStats;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

		enemyStats = GetComponent<EnemyStats> ();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update () {

        if (agent.enabled == true && agent.remainingDistance < remainingDistance)
        {
            agent.enabled = false;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", true);
            StartCoroutine(RandomMovement());
            Debug.Log("Arrived");
        }
        //Alert
        if (Vector3.Distance(player.position, transform.position) < alertDistance &&
            Vector3.Distance(player.position, transform.position) > walkingDistance)
        {
            agent.enabled = false;
            meshRendererFlag.material.color = Color.yellow;
            animator.SetBool("IsAlert", true);
            animator.SetBool("IsIdle", false);

            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", false);
        }

        //ChaseAttack
        else if (Vector3.Distance(player.position, transform.position) <= walkingDistance)
        {
            agent.enabled = true;
            
            agent.SetDestination(player.transform.position);

            animator.SetBool("IsWalking", true);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsAlert", false);
            animator.SetBool("IsIdle", false);

            if(direction.magnitude <= attackingDistance)
            {
                meshRendererFlag.material.color = Color.red;
                animator.SetBool("IsAttacking", true);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalking", false);


            }
        }
        //Idle
        else if (animator.GetBool ("IsIdle") == false && agent.enabled == false)
        {
            meshRendererFlag.material.color = Color.blue;
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsAlert", false);
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsWalking", false);

            StartCoroutine(RandomMovement());
        }

	}
    //Patrol
    public IEnumerator RandomMovement()
    {
        int index = Random.Range(minTime, maxTime);

        yield return new WaitForSeconds(index);
        int index2 = Random.Range(1, 3);
        switch (index2)
        {
            case 1:
                meshRendererFlag.material.color = Color.blue;
                Debug.Log("Keep Idle...");
                StartCoroutine(RandomMovement());
                break;
            case 2:

                meshRendererFlag.material.color = Color.green;
                Debug.Log("Patrolling...");
                agent.enabled = true;

                selectedDestination = Random.Range(0, DestinationPoints.Count);
                agent.SetDestination(DestinationPoints[selectedDestination].transform.position);
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsAlert", false);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalking", true);
                break;
        }
    }

	public void DamageTo() {
		PlayerStats playerStats = player.GetComponent<PlayerStats> ();
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward, out hit, attackingDistance)) {
			if (hit.collider.tag == "Player") {
				playerStats.DeductHealth(enemyStats.strength);
			}
		}
	}
}
