﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : MonoBehaviour {

	public delegate void EnemyEventHandler(EnemyStats enemy);
	public static event EnemyEventHandler OnEnemyDeath;

	public static void EnemyDied(EnemyStats enemy) {
		if (OnEnemyDeath != null)
			OnEnemyDeath (enemy);
	}
}
