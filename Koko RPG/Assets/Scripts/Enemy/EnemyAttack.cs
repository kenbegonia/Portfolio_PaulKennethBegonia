using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public PlayerStats player;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player")
        {
            player.DeductHealth(10);
        }
    }
}
