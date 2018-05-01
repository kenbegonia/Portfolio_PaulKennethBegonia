using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Gold")]
public class GoldItem : Item {

	public int value;

	public override bool Use ()
	{
		PlayerStats playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		playerStats.AddGold (value);

		return true;
	}
}
