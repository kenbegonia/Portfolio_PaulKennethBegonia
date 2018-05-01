using UnityEngine;
using System.Collections;

public class PlayerStateBehavior : MonoBehaviour {

	public Transform chooseTarget;
	public Transform createRaycast;
	public Transform movePoint;
	public Transform attackPoint;
	public PlayerStats player;
	public UnityEngine.AI.NavMeshAgent nav;
	public Animator anim;
	public IPlayerState currentState;
	public PlayerIdleState idleState;
	public PlayerMoveState moveState;
	public PlayerChaseState chaseState;
	public PlayerAttackState attackState;

	void Awake()
	{
		player = GetComponent<PlayerStats> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		moveState = new PlayerMoveState (this);
		idleState = new PlayerIdleState (this);
		chaseState = new PlayerChaseState (this);
		attackState = new PlayerAttackState (this);
	}

	void Start()
	{
		currentState = idleState;
	}

	void Update()
	{
		currentState.UpdatePlayerState ();
	}
}
