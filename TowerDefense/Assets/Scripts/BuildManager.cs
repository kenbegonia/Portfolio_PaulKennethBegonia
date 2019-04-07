using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	[SerializeField] GameObject prefabTower;
	[SerializeField] GameObject objectTower;
	public GoldMgr goldMgr;
	public TowerScript towerScript;
	public TowerConfig towerConfig;
	private float buildCost;
	private float buildTime;
	private TowerStatusDisplay towerStat;

	void Start () {
		buildCost = towerConfig.goldPrice;
		buildTime = towerConfig.buildTime;
	}

	void Update () {
		SelectArea();
	}

	public void CreateTower()
	{
		if (GoldMgr.Gold >= buildCost) {
			GameObject twr = Instantiate (prefabTower) as GameObject;
			objectTower = twr;
		} else
			TowerStatusDisplay.towerStat.text = "Insufficient gold";
	}

	Vector3 SnapToGrid(Vector3 towerObject)
	{
		return new Vector3(Mathf.Round(towerObject.x),
							towerObject.y,
							Mathf.Round(towerObject.z));
	}

	void SelectArea() {

		if (objectTower != null) 
		{	
			ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			if (Physics.Raycast (ray, out hit)) {
				Vector3 towerPos = hit.point;
				objectTower.transform.position = SnapToGrid(towerPos);
				//Debug.Log (hit.point);

				if (hit.point.y > 1 && hit.point.y < 3) 
				{
					objectTower.GetComponent<TowerScript> ().Buildable ();

					if (Input.GetMouseButtonDown (0)) 
					{
						GoldMgr.Gold -= buildCost;
						objectTower.GetComponent<TowerScript> ().Build ();
						objectTower = null;
					}
				}
				else
					objectTower.GetComponent<TowerScript> ().NonBuildable ();

				Debug.DrawLine (ray.origin, hit.point, Color.red);
			}
		}
	}
}
