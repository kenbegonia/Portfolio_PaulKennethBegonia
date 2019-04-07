using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour {
	public GoalLife goalLife;
	Text lifeTxt;

	// Use this for initialization
	void Start () {
		lifeTxt = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		lifeTxt.text = " " + GoalLife.Life;
	}
}
