using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : Skill {

	public float m_duration;
	public int m_strengthBonus;
	public int m_intelligenceBonus;

	private Transform m_center;
	public GameObject blessingAnim;
	private bool m_isActive = false;
	private float m_timer;

	void Start () {
		base.Initialize ();
		m_timer = m_duration;
		m_center = m_caster.gameObject.transform;

	}

	void Update() {
		if (m_isActive) {
			m_timer -= Time.deltaTime;
		}

		if (m_timer <= 0) {
			m_isActive = false;
			m_caster.strength -= m_strengthBonus;
			m_caster.intelligence -= m_intelligenceBonus;
			m_timer = m_duration;
		}

		Debug.Log ("duration " + m_timer);
	}

	public override void Use () {
        base.Use();
		m_center = m_caster.gameObject.transform;
		GameObject bless = Instantiate (blessingAnim, m_center.position, Quaternion.identity) as GameObject;
		Destroy (bless, 0.8f);
        Debug.Log("BLESSING!");
        m_isActive = true;
		m_caster.strength += m_strengthBonus;
		m_caster.intelligence += m_intelligenceBonus;
	}
}
