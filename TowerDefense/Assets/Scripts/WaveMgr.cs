using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveMgr : MonoBehaviour {
	public EnemySpawnMgr enemyMgr;
	Text waveTxt;

	// Use this for initialization
	void Start () {
		waveTxt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		waveTxt.text = "Wave " + EnemySpawnMgr.waveNumber;
	}
}
