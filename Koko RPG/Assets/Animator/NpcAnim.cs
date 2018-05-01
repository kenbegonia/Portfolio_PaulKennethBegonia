﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnim : MonoBehaviour {

    Animator animator;

    public bool IsIdle;

	void Start () {
        animator = GetComponent<Animator>();
    }

    public void AnimationTransition(int value)
    {
        animator.SetInteger("AnimationID", value);
    }
}
