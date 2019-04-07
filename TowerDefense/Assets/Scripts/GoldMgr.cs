using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldMgr : MonoBehaviour {
	public static float Gold = 500;
	Text goldTxt;

	// Use this for initialization
	void Start () {
		goldTxt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		goldTxt.text = " " + Gold;
	}
}
