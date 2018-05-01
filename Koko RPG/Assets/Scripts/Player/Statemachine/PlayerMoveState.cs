using UnityEngine;
using System.Collections;

public class PlayerMoveState : IPlayerState {

	PlayerStateBehavior player;
	PlayerMoveControl target;

	public PlayerMoveState (PlayerStateBehavior playerBehavior)
	{
		player= playerBehavior;
	}
	public void UpdatePlayerState ()
	{
		Move ();	
	}
	public void ToPlayerIdleState ()
	{
		player.currentState = player.idleState;
	}
	public void OnTriggerEnter (Collider other)
	{

	}
	public void ToPlayerMoveState ()
	{
		player.currentState = player.moveState;
	}
	public void ToPlayerChaseState ()
	{
		player.currentState = player.chaseState;
	}
	public void ToPlayerAttackState()
	{
		player.currentState = player.attackState;
	}

	void Move()
	{
		if (player.nav.destination != player.movePoint.position) {
			player.nav.SetDestination (player.movePoint.transform.position);
			player.anim.SetInteger ("AnimationID", 1);
		}

		if (Vector3.Distance (player.transform.position, player.movePoint.transform.position) < .5f) {
			player.currentState = player.idleState;
		}
		Debug.Log ("MOVE STATE");
	}
}
