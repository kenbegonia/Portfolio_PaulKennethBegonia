using UnityEngine;
using System.Collections;

public class PlayerAttackState : IPlayerState{

	PlayerStateBehavior playerState;

	public PlayerAttackState(PlayerStateBehavior playerStateBehavior)
	{
		playerState = playerStateBehavior;
	}
	public void UpdatePlayerState ()
	{
		Attack ();
		LookTarget ();
		StopAttack ();
	}
	public void ToPlayerIdleState ()
	{
		playerState.currentState = playerState.idleState;
	}
	public void OnTriggerEnter (Collider other)
	{

	}
	public void ToPlayerMoveState ()
	{
		playerState.currentState = playerState.moveState;
	}
	public void ToPlayerChaseState ()
	{
		playerState.currentState = playerState.chaseState;
	}
	public void ToPlayerAttackState()
	{
		playerState.currentState = playerState.attackState;
	}
	void Attack ()
	{
		if (playerState.attackPoint == null)
			return;
		playerState.anim.SetInteger ("AnimationID", 2);
		Debug.Log ("ATTACK STATE");
		if (Vector3.Distance(playerState.transform.position, playerState.attackPoint.transform.position) > 2f) {
			
			ToPlayerChaseState();
		}
	}

	void LookTarget()
	{
        if (playerState.attackPoint == null)
            return;
		Vector3 Direction = (playerState.attackPoint.transform.position);
		if (Direction == null)
			return;
		Quaternion lookRotation = Quaternion.LookRotation (Direction);

	}

	void StopAttack()
	{
		if (playerState.attackPoint == null) {
			playerState.currentState = playerState.idleState;
		}
	}
}
