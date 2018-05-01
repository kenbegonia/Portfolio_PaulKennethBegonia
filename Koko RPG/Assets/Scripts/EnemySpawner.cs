using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] Enemies;
    private float monsterCount = 0;
    public float MinMass = 0.3f;
    public float MaxMass = 5.0f;
    public Vector3 MinSpawnPoint;
    public Vector3 MaxSpawnPoint;
    public float MinSpawnInterval = 1.0f;
    public float MaxSpawnInterval = 3.0f;
    public float MaxSpawn;
    public int Enemyone;
    private GameObject EnemyChose;

    void Start()
    {
        StartCoroutine(SpawnTask());
    }

    void update()
    {
        this.transform.position = new Vector3
            (Mathf.Clamp(this.transform.position.x, -20f, 20f),
                Mathf.Clamp(this.transform.position.y, -20f, 20f),
                0);
    }
    IEnumerator SpawnTask()
    {
        while (monsterCount <= MaxSpawn)
        {
            float waitTime = Random.Range(MinSpawnInterval, MaxSpawnInterval);
            Debug.Log("Monster Spawned: " + monsterCount);
            monsterCount++;
            yield return new WaitForSeconds(waitTime);

            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Enemyone = Random.Range(0, Enemies.Length);
        EnemyChose = Enemies[Enemyone];
        float x = Random.Range(MinSpawnPoint.x, MaxSpawnPoint.x);
        float y = Random.Range(MinSpawnPoint.y, MaxSpawnPoint.y);
        float z = Random.Range(MinSpawnPoint.z, MaxSpawnPoint.z);
        Instantiate(EnemyChose, new Vector3(x, y, z), Quaternion.identity);
    }
}