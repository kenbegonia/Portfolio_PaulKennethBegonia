using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill {
	public int m_restorePoints;
    PlayerStats playerstats;
	private Transform m_center;
	public GameObject healAnim;

    public override void Use () {
		base.Use ();
		m_center = m_caster.gameObject.transform;
		GameObject heal = Instantiate (healAnim, m_center.position, Quaternion.identity) as GameObject;
		Destroy (heal, 0.8f);
        Debug.Log("HEAAAAAAAAL!");
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        m_caster.currentMana -= m_manaPointsCost;
        playerStats.AddHealth (m_restorePoints);
	}
}
