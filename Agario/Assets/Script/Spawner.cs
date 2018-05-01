using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject prefabToSpawn;
	public int startFoodCount;
	public int currFoodCount = 0;
	public float spawnRate = 1.5f;
	private int maxFoodCount = 100;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= startFoodCount; i++) 
		{
			Invoke ("Spawn", 1.0f);
		}

		StartCoroutine (StartSpawning ());
	}

	//waiting time for starting each food/enemy spawn
	IEnumerator StartSpawning()
	{
		//code to run the Spawn function every 1.5secs forever
		while (true) 
		{
			Spawn ();
			yield return new WaitForSeconds(spawnRate);
		}
	}

	//spawn asteroid itself
	void Spawn()
	{
		float spawnPtX = Random.Range (-45.7f, 32.6f);
		float spawnPtY = Random.Range (-38.6f, 45.7f);
		Vector3 randomPos = new Vector3 (spawnPtX, spawnPtY, 0);

		GameObject spawnObj = (GameObject)Instantiate (prefabToSpawn, randomPos, Quaternion.identity);
		spawnObj.transform.SetParent (this.transform);
		Debug.Log ("Spawned!");

		currFoodCount++;
	}
}
