using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Curse : Skill {

    public int m_decrease;
    public float m_radius;
    public float effectTime;
    private Transform m_center;
    private bool isCursed;

	public GameObject curseAnim;
    // Use this for initialization
    void Start()
    {
        base.Initialize();
        m_center = m_caster.gameObject.transform;
    }

    void EndEffect()
    {
        isCursed = false;
    }

    public override void Use()
    {
        isCursed = true;

        base.Use();
        m_center = m_caster.gameObject.transform;
        Debug.Log("Curse!");
     
        Collider[] hitColliders = Physics.OverlapSphere(m_center.position, m_radius);
        
        for (int i = 0;  i < hitColliders.Length; i++)
        {
            Unit unit = hitColliders[i].GetComponent<Unit>();
            //NavMeshAgent nav = unit.GetComponent<NavMeshAgent>();
            if (m_caster != null)
                Debug.Log("CASTER!");

            if (unit != null && isCursed == true)
            {
                if (!isCursed)
                {
                    Invoke("EndEffect", 5.0f);
                }

                //If it's not the player/caster, cast curse
                if (unit != m_caster)
                {
					GameObject curse = Instantiate (curseAnim, unit.transform.position, Quaternion.identity) as GameObject;
					Destroy (curse, 0.8f);
                    unit.strength -= m_decrease;
                    unit.intelligence -= m_decrease;
                    //nav.speed = 0.5f;
                    Debug.Log("enemy STR and INT decreased!");
                }

                if (isCursed == false)
                {
                    unit.strength += m_decrease;
                    unit.intelligence += m_decrease;
                    //nav.speed = 1.0f;
                    Debug.Log("enemy STR and INT reverted!");
                }
            }
        }
    }
}
