using UnityEngine;
using System.Collections;

public class PlayerIdleState : IPlayerState{

	PlayerStateBehavior playerState;
    
    public PlayerIdleState (PlayerStateBehavior playerStateBehavior)
	{
		playerState = playerStateBehavior;
	}
	public void UpdatePlayerState ()
	{
		Idle ();
	}
	public void ToPlayerIdleState ()
	{

	}
	public void OnTriggerEnter (Collider other)
	{

	}
	public void ToPlayerMoveState ()
	{

	}
	public void ToPlayerChaseState ()
	{

	}
	public void ToPlayerAttackState()
	{

	}

	void Idle()
	{
		Debug.Log ("IDLE STATE");
		playerState.anim.SetInteger("AnimationID" , 0);
    }
}
