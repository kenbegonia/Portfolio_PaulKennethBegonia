using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyType
{
	Boss,
	Ground,
	Flying,
}

public class EnemyDeath : UnityEvent<Enemy>{}

public class Enemy : MonoBehaviour {
	public EnemyDeath onDeath = new EnemyDeath ();
	public EnemyType type;
	public EnemyConfig enemyConfig;
	public EnemySpawnMgr spawnMgr;
	private List<Enemy> listOfEnemies = new List<Enemy> ();
	private GoldMgr goldMgr;
	public float maxLife;
	public float currLife;
	public float Drop;


	// Use this for initialization
	void Start () {
		maxLife = enemyConfig.Life;
		currLife = maxLife;
		Drop = enemyConfig.goldDrop;
		listOfEnemies = EnemySpawnMgr.enemyList;

		Debug.Log ("Spawned: " + this.type);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currLife <= 0) 
		{
			Destroy (this.gameObject);
		}
	}

	/// <summary>
	/// Called if the enemy has died.
	/// </summary>
	public void Death()
	{
		EnemySpawnMgr.enemyNumberInField--;
		listOfEnemies.Remove (this);	
		GoldMgr.Gold += Drop;

		onDeath.Invoke (this);
		Debug.Log ("Dropped gold: " + Drop);
	}

	public void OnDestroy()
	{
		Death ();
	}
}
