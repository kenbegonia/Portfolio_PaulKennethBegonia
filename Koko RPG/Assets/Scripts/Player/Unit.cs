using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public int level;

	public int currentHealth;
	public int maxHealth;

    public int currentMana;
    public int maxMana;

    protected float manaRegen;
    public int strength;
    public int vitality;
    public int intelligence;
    public int spirit;
    public int magicalAttackPower;

    protected virtual void InitializeUnit() {
		currentHealth = maxHealth;
        currentMana = maxMana;

        magicalAttackPower = 20;
    }

	protected virtual void UnitUpdate() {
        manaRegen = ((spirit / 10) * Time.deltaTime);

        NoOverHp ();
        NoOverMp();
		Die ();
	}

	protected void NoOverHp()
	{
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}

    protected void NoOverMp()
    {
        if (currentMana > maxMana)
            currentMana = maxMana;
    }

    public virtual void Die()
	{
		//Do not proceed if health is greater than 0
		if (currentHealth > 0)
			return;
	}

	public void DeductHealth (int value) {
		if (value < 0)
			value = 0;

		currentHealth -= value;
	}

	public void AddHealth (int value) {
		if (value < 0)
			value = 0;

		currentHealth += value;
	}

    public void AddMana (int value)
    {
        if (value < 0)
            value = 0;

        currentMana += value;
    }
}
