using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMgr : MonoBehaviour {
	public static int Score;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		Score = 0;
	}

	// Update is called once per frame
	void Update () {
		text.text = "SCORE: " + Score;
	}
}
