using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class BulletData : ScriptableObject {
    public string b_Name;
    public GameObject b_Prefab;
    public float b_Velocity;
    public float b_Mass;
    public float b_Damage;
    public bool hasAnimation;
    public Animation animation;
    public BulletDmgType dmgType;
}
