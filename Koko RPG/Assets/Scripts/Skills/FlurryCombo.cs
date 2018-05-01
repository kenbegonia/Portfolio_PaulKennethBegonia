using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class FlurryCombo :Skill {

    public float dmgMultiplier;
    public float m_radius;
    public Collider[] hitColliders;
    public int basicDmg;
    private int m_damage;
    private Transform m_center;
    private Unit toDamage;

	// Use this for initialization
	void Start () {
        base.Initialize();
        m_damage = basicDmg * m_caster.strength;
        m_center = m_caster.gameObject.transform;
	}
	
    public override void Use()
    {
        base.Use();
        m_center = m_caster.gameObject.transform;
        Debug.Log("FLURRY COMBO!");
        hitColliders = Physics.OverlapSphere(m_center.position, m_radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            toDamage = hitColliders[i].GetComponent<Unit>();
            if (toDamage != null)
            {
                //If it's not the player/caster, deduct health
                if (toDamage != m_caster)
                {
					
					anim.SetInteger ("AnimationID", 4);
                    toDamage.DeductHealth(m_damage);
                    Debug.Log("Damaged! Dealt dmg: " + m_damage);
                }
            }
        }
    }
}
