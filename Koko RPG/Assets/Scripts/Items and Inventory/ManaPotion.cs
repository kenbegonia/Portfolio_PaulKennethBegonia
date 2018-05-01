using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Mana Potion")]
public class ManaPotion : Item
{

    public int restorePoints;

    public override bool Use()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.AddMana(restorePoints);


        Inventory.m_instance.Remove(this);
        return true;
    }
}
