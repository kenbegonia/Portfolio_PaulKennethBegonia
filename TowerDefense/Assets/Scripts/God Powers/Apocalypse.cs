using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apocalypse : GodPowers {
	public EnemySpawnMgr spawnMgr;
	public List<Enemy> toDestroy;

	public override void Power (bool coolDown)
	{
		base.Power (coolDown);

		if (coolDown == false) 
		{
			toDestroy = EnemySpawnMgr.enemyList;

			for (int i = 0; i < toDestroy.Count; i++) 
			{
				if (toDestroy[i].type != EnemyType.Boss) 
				{
					Destroy (toDestroy[i].gameObject);
					toDestroy.Remove (toDestroy[i]);
				}
			}

			CoolDown ();
			Debug.Log ("Power: Apocalypse");
		}
	}
}
