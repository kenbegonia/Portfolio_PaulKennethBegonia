using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotSelected : SkillSlot {
    private Button btn;
    private bool isCoolingDown = false;

    public void Start()
    {
        btn = GetComponent<Button>();
    }

    public override void UseSkill ()
    {
		if (m_skill != null && isCoolingDown == false) {
			m_skill.Use ();
            Debug.Log(m_skill.m_name + " skill clicked");

            if (!isCoolingDown)
            {
                isCoolingDown = true;
                btn.interactable = false;
                Debug.Log("Skill cooling down");
                Invoke("StopCooldown", time: m_skill.m_cooldown);
            }
        }
    }

    public void StopCooldown()
    {
        isCoolingDown = false;
        btn.interactable = true;
        Debug.Log(m_skill.m_name + " ready");
    }

}
