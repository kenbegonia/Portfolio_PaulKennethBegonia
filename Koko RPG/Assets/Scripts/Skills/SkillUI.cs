using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : SubsystemUI {

	PlayerSkillManager m_skillManager;
	public SkillSlot[] m_slots;

	void Start () {
		m_skillManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkillManager>();

		m_slots = m_parent.GetComponentsInChildren<SkillSlot>();
		m_skillManager.onSkillsUpdateCallback += UpdateUI;
		UpdateUI ();
	}

	public override void UpdateUI () {
		base.UpdateUI ();
		for (int i = 0; i < m_slots.Length; i++) {
			if (i < m_skillManager.m_skills.Count)
				m_slots [i].AddSkill (m_skillManager.m_skills [i]);
			else
				m_slots [i].ClearSlot ();
		}
	}
}
