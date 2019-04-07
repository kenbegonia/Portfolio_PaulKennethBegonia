using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusDisplay : MonoBehaviour {
	public static Text towerStat;
	// Use this for initialization
	void Start () {
		towerStat = GetComponent<Text> ();
	}
}
