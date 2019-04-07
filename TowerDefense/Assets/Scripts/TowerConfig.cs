using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Tower Configuration")]
public class TowerConfig : ScriptableObject {
	public float buildTime;
	public float fireRate;
	public float damage;
	public float goldPrice;
}
