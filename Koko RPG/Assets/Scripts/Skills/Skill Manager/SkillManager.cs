using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	public Unit m_unit;
	public int m_space = 4;

	public List<Skill> m_skills = new List<Skill> ();

    // Use this for initialization
    void Start () {
		m_unit = gameObject.GetComponent<Unit> ();
		m_skills.ForEach (s => s.m_caster = m_unit);
		m_skills.ForEach (s => s.CheckLevel ());
	}
}
