using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnMgr : MonoBehaviour {

	private Vector3 randPos;
	private int enemySpawnCount = 6;
	public int enemyInField;
	public static int enemyNumberInField = 0;
	public static int waveNumber = 0;
	private float spawnRate = 0.5f;
	private float bossSpawnAppearance = 5.0f;
	public Enemy spawnEnemyA;
	public Enemy spawnEnemyB;
	public Enemy spawnEnemyBoss;
	public static List<Enemy> enemyList =  new List<Enemy>();
	private int randIndex;

	// Use this for initialization
	void Start () 
	{
		spawnEnemyA.onDeath.AddListener (OnDeath);
		spawnEnemyB.onDeath.AddListener (OnDeath);
		spawnEnemyBoss.onDeath.AddListener (OnDeath);

		StartCoroutine (SpawnTimer ());
	}

	/// <summary>
	/// Scans the number of enemies that are currently active,
	/// and spawns a fresh batch of enemies if they are all dead.
	/// Once every 5 waves, a boss will spawn with the wave.
	/// </summary>
	/// <returns>The timer.</returns>
	IEnumerator SpawnTimer()
	{
		while (true)
		{
			waveNumber++;

			for (int i = 0; i < enemySpawnCount / 2; i++)
			{
				SpawnEnemy (spawnEnemyA);
				yield return new WaitForSeconds (spawnRate);
			}

			for (int i = 0; i < enemySpawnCount / 2; i++)
			{
				SpawnEnemy (spawnEnemyB);
				yield return new WaitForSeconds (spawnRate);
			}

			if (waveNumber % bossSpawnAppearance == 0)
			{
				SpawnEnemy(spawnEnemyBoss);
			}

			AddStats ();
			enemySpawnCount++;

			if (enemyNumberInField <= 0) 
			{
				enemyList.Clear ();
			}

			yield return new WaitUntil(()=> enemyNumberInField <= 0);
		}
	}

	void AddStats()
	{
		Enemy enemyStats = spawnEnemyA.GetComponent<Enemy> ();

		enemyStats.maxLife = enemyStats.maxLife * 1.5f;
		enemyStats.Drop = enemyStats.Drop * 1.5f;
	}

	// Update is called once per frame
	void Update () 
	{
		enemyInField = enemyNumberInField;
		randIndex = Random.Range (0, 1);
	}

	/// <summary>
	/// Spawns the enemy to a set position.
	/// </summary>
	/// <param name="spawnObject">Spawn object.</param>
	void SpawnEnemy(Enemy spawnObject)
	{
		float posX = Random.Range (55.0f, 58.0f);
		float posY = Random.Range (0.8f, 2.5f);
		float posZ = Random.Range (46.2f, 46.5f);

		randPos = new Vector3 (posX, posY, posZ);

		Enemy enemyA = (Enemy)Instantiate (spawnObject, randPos, Quaternion.identity);

		enemyA.transform.SetParent (this.transform);

		enemyList.Add (enemyA);

		enemyNumberInField++;
	}

	void OnDeath(Enemy _enemy)
	{
		enemyList.Remove (_enemy);
		enemyNumberInField--;

		Debug.Log ("OnDeath event is working....probably");
	}
}
