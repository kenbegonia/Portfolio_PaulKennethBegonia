using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

	public string m_name;
	public string m_description;
	public int m_manaPointsCost;
	public float m_cooldown;
    public bool m_isUnlocked;
	public int m_levelRequired;
	public Unit m_caster;
	public Animator anim;

	public void Initialize () {
		m_caster = GetComponent<Unit> ();
		anim = GetComponent<Animator> ();
	}

	public void CheckLevel() {
		if (m_caster.level >= m_levelRequired)
			m_isUnlocked = true;
	}

    public virtual void Use () {
        if (IsAvailable() && !m_isUnlocked)
            return;
    }

    protected bool IsAvailable () {
        if (m_cooldown <= 0 && m_caster.currentMana >= m_manaPointsCost)
            return true;
        else
            Debug.Log("Unusable!");
			return false;
	}
}
