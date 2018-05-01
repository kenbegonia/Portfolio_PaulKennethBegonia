using UnityEngine;
using System.Collections;

public class EnemyStats : Unit
{

	public string m_ID;
	private PlayerStats playerStats;
    public int dropExperience;
	public ItemDrop drop;

	void Start()
    {
		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
        currentHealth = maxHealth;
    }


    void FixedUpdate()
    {
        Die();
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            GiveExp();
			drop.ItemDropDeath(this.transform.position);
			CombatEvent.EnemyDied (this);
            Destroy(this.gameObject);
        }
    }
		
    void GiveExp()
    {
        playerStats.currentExperience += dropExperience;
    }
}
