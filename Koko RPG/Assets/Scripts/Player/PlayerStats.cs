using UnityEngine;
using System.Collections;
using System;

public class PlayerStats : Unit {

	Animator anim;
    public int currentExperience;
	private int levelUpBaseValue;
	public int levelUpValue;
	public int statPoints;
	private float baseMultiplier;
	public int gold;

	public delegate void OnPlayerLevelUp ();
	public OnPlayerLevelUp onPlayerLevelUpCallback;
	public static event OnPlayerLevelUp LvUp;

    void Awake()
	{
		anim = GetComponent<Animator> ();
        level = 1;
		maxHealth = 100;
        maxMana = 100;
		strength = 10;
		vitality = 10;
		gold = 100;
		levelUpBaseValue = 50;
		levelUpValue = levelUpBaseValue;
		baseMultiplier = 2.0f;
	}

	void OnLevelUp()
	{
		level += 1;
		currentExperience = 0;
		baseMultiplier = baseMultiplier * 1.5f;
		levelUpBaseValue = levelUpBaseValue * Convert.ToInt32(baseMultiplier);
		levelUpValue = levelUpBaseValue;
		statPoints += 5;

		Debug.Log("You leveled up! Current level: " + level);
	}

	void OnDisable()
	{
		LvUp -= OnLevelUp;
	}

	void OnEnable()
	{
		LvUp += OnLevelUp;
	}

	void Start()
	{
		base.InitializeUnit ();
	}

	void Update()
	{
		UnitUpdate ();
	}

	protected override void UnitUpdate ()
	{
		if (currentExperience >= levelUpValue)
		{
			if (LvUp != null)
			{
				OnLevelUp();
			}
		}

		base.UnitUpdate ();
	}

    void LevelUp()
    {
        if (currentExperience >= levelUpValue)
        {
            level += 1;
            currentExperience = 0;
            levelUpValue += 50;
            statPoints += 5;

			if (onPlayerLevelUpCallback != null)
				onPlayerLevelUpCallback.Invoke ();
        }
    }

	public override void Die ()
	{
		base.Die ();
	}
    
	public void RaiseStrenght () {
		if (statPoints <= 0) {
			Debug.Log ("Not enough stat points!");
			return;
		}
        strength += 1;
		statPoints -= 1;
	}

	public void RaiseVitality () {
		if (statPoints <= 0) {
			Debug.Log ("Not enough stat points!");
			return;
		}

		vitality += 1;
        maxHealth += 10;
        statPoints -= 1;
	}

	public void RaiseIntelligence () {
		if (statPoints <= 0) {
			Debug.Log ("Not enough stat points!");
			return;
		}
        maxMana += 10;
		intelligence += 1;
		statPoints -= 1;
	}

	public void DeductStrength () {
		if (strength < 0)
			return;

		strength -= 1;
		statPoints += 1;
	}

	public void DeductVitality () {
		if (vitality < 0)
			return;

		vitality -= 1;
		statPoints += 1;
	}

	public void DeductIntelligence () {
		if (intelligence < 0)
			return;

		intelligence -= 1;
		statPoints += 1;
	}

	public void AddGold (int value) {
		if (value <= 0)
			return;
		
		gold += value;
	}

	public void DeductGold (int value) {
		if (value <= 0)
			return;

		gold -= value;
	}
}
