using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {
    public PlayerStats playerstats;
    public HealthPotion hpPotion;
    public ManaPotion mpPotion;
    public PowerSource sourcePotion;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyHealthPotion()
    {
        if (playerstats.gold <= 0)
        {
            Debug.Log("Not enough gold!");
            return;
        }
        Debug.Log("You Bought ");
        playerstats.DeductGold(10);
        Inventory.m_instance.Add(hpPotion);
    }

    public void BuyManaPotion()
    {
        if (playerstats.gold <= 0)
        {
            Debug.Log("Not enough gold!");
            return;
        }
        Debug.Log("You Bought ");
        playerstats.DeductGold(10);
        Inventory.m_instance.Add(mpPotion);
    }

    public void BuySourcePotion()
    {
        if (playerstats.gold <= 0)
        {
            Debug.Log("Not enough gold!");
            return;
        }
        Debug.Log("You Bought ");
        playerstats.DeductGold(15);
        Inventory.m_instance.Add(sourcePotion);
    }
}
