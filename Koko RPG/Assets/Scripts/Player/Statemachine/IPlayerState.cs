using UnityEngine;
using System.Collections;

public interface IPlayerState  {

	void UpdatePlayerState ();
	void ToPlayerIdleState ();
	void OnTriggerEnter (Collider other);
	void ToPlayerMoveState ();
	void ToPlayerChaseState ();
	void ToPlayerAttackState();
}
