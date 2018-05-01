using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
	public GameObject prefabToSpawn;
	public float spawnRate;

	// Use this for initialization
	void Start () {
		StartCoroutine (StartSpawning ());
	}

	//waiting time for starting each asteroid spawn
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
		float spawnPtY = Random.Range (-4.0f, 4.0f);
		Vector3 randomPos = new Vector3 (13.0f, spawnPtY, -1.0f);

		GameObject spawnObj = (GameObject)Instantiate (prefabToSpawn, randomPos, Quaternion.identity);
		spawnObj.transform.SetParent (this.transform);
		Debug.Log ("Spawned!");

		//destroy spawns after 3secs. for less clones
		Destroy (spawnObj, 3.0f);
	}
}
