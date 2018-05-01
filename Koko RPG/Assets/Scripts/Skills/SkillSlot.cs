using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour {
	public Text m_name;
	private SkillSlotSelected m_selectedSlot;
	public Skill m_skill;

	void Start() {
		m_selectedSlot = GameObject.Find ("Selected Skill").GetComponent<SkillSlotSelected> ();
	}

	public void AddSkill(Skill skill) {
		m_skill = skill;
		m_name.text = skill.m_name;
	}

	public void ClearSlot() {
		m_skill = null;
		m_name.text = null;
	}

	public virtual void UseSkill() {
			m_selectedSlot.AddSkill (m_skill);
	}
}
