using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : Skill {

	public GameObject m_fireball;

	public override void Use () {
		base.Use ();
        Debug.Log("FIREBALL!");
        GameObject projectile = (GameObject)Instantiate (m_fireball, m_caster.transform.position, transform.rotation);
		Projectile fireball = projectile.GetComponent<Projectile> ();
		fireball.m_damage = m_caster.magicalAttackPower;
		fireball.m_caster = m_caster;
	}
}
