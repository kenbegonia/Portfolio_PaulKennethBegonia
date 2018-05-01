using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Health Potion")]
public class HealthPotion : Item {

	public int restorePoints;

	public override bool Use ()
	{
		PlayerStats playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		playerStats.AddHealth (restorePoints);


		Inventory.m_instance.Remove (this);
		return true;
	}
}
