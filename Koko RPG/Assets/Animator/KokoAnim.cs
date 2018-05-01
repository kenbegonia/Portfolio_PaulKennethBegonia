using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KokoAnim : MonoBehaviour
{

    Animator animator;

    public bool IsIdle;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimationTransition(int value)
    {
        animator.SetInteger("AnimationID", value);
    }

    public void BlendTransition(float value)
    {
        animator.SetFloat("Blend", value);
    }
}
