using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Power Source")]
public class PowerSource : Item
{
    public int additionalStat;

    public override bool Use()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.strength += additionalStat;

        //playerStats.strength -= additionalStat;

        Inventory.m_instance.Remove(this);
        return true;


    }
}
