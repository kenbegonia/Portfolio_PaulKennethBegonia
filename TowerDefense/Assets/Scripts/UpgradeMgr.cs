using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMgr : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    [SerializeField] GameObject upgradedTower;
    public GoldMgr goldMgr;
    public TowerConfig towerConfig;
    private float buildCost;
    private float buildTime;
    private TowerStatusDisplay towerStat;
    [SerializeField]private Tower towerA;
    private Tower towerB;
    bool isSearching;

    void Start()
    {
        isSearching = false;
        buildCost = towerConfig.goldPrice;
        buildTime = towerConfig.buildTime;
    }

    void Update()
    {
        if (isSearching == true)
            SelectArea();
    }

    public void SelectArea()
    {
        isSearching = true;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            towerA = hit.collider.GetComponent<Tower>();
            towerB = upgradedTower.GetComponent<Tower>();

            Debug.Log("searching for " + towerConfig.name + " tower to upgrade");
            Debug.DrawLine(ray.origin, hit.point, Color.blue);

            if(Input.GetMouseButtonDown(0))
            {
                if (towerA.gameObject.tag.Equals("Tower") && towerA.towerType == towerB.towerType)
                {
                    if (GoldMgr.Gold >= buildCost)
                    {
                        Debug.Log("Can upgrade.");
                        Instantiate(upgradedTower, towerA.transform.position, towerA.transform.rotation);
                        Destroy(towerA.gameObject);
                    }
                    else
                        TowerStatusDisplay.towerStat.text = "Insufficient gold";
                }

                else Debug.Log("Tower not detected");

                isSearching = false;
            }
        }
    }
}
