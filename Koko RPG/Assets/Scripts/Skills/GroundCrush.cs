using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCrush : Skill {

	public float m_radius;
	public float m_damage;
	private Transform m_center;
	public GameObject groundAnim;
	void Start () {
		base.Initialize ();
		m_center = m_caster.gameObject.transform;
	}

	public override void Use () {
		base.Use ();
		m_center = m_caster.gameObject.transform;
		GameObject ground = Instantiate (groundAnim, m_center.position, Quaternion.identity) as GameObject;
		Destroy (ground, 0.8f);
        Debug.Log("GROUND CRUSH!");
        Collider[] hitColliders = Physics.OverlapSphere (m_center.position, m_radius);
		
		for (int i = 0; i < hitColliders.Length; i++) {
			Unit unit = hitColliders [i].GetComponent<Unit> ();
			if (m_caster != null)
				Debug.Log ("CASTER!");

			if (unit != null) {
				//If it's not the player/caster, deduct health
				if (unit != m_caster)
					unit.DeductHealth (m_caster.magicalAttackPower);
			}

		}
	}
}
