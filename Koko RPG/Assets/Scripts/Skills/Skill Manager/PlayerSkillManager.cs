using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : SkillManager {

	public PlayerStats m_playerStats;

	public delegate void OnSkillsUpdate();
	public OnSkillsUpdate onSkillsUpdateCallback;

	// Use this for initialization
	void Start () {
		m_playerStats = GetComponent<PlayerStats> ();
		m_skills.ForEach (s => s.m_caster = m_playerStats);

		if (onSkillsUpdateCallback != null)
			onSkillsUpdateCallback.Invoke ();
	}

	public void AddSkill(Skill skill) {
		if (m_skills.Count >= m_space)
			return;

		if (m_skills.Contains (skill))
			return;

		skill.Initialize ();
		m_skills.Add (skill);

		if (onSkillsUpdateCallback != null)
			onSkillsUpdateCallback.Invoke ();
	}
}
