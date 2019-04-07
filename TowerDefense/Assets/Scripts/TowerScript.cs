using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

	[SerializeField]Material towerMat;
	public int buildCost;
	public GoldMgr goldMgr;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Buildable()
	{
		towerMat.color = Color.green;
	}

	public void NonBuildable()
	{
		towerMat.color = Color.red;
	}

	public void Build()
	{
		towerMat.color = Color.white;
	}
}
