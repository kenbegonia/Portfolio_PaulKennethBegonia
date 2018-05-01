using UnityEngine;
using System.Collections;

public class PlayerChaseState : IPlayerState {

	PlayerStateBehavior playerState;
    

	public PlayerChaseState (PlayerStateBehavior playerStateBehavior)
	{
		playerState = playerStateBehavior;
	}

	public void UpdatePlayerState ()
	{
		Chase ();
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
		Debug.Log ("CHASING...");
	}
	public void ToPlayerAttackState()
	{
		playerState.currentState = playerState.attackState;
	}

	void Chase()
	{
		playerState.nav.SetDestination (playerState.attackPoint.transform.position);

		if (Vector3.Distance(playerState.transform.position, playerState.attackPoint.transform.position) <= 1f) {
			ToPlayerAttackState ();
		}
		playerState.anim.SetInteger ("AnimationID", 1);
		Debug.Log ("CHASE STATE");

    }
}
