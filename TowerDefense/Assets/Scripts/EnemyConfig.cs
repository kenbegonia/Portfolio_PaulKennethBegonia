using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy Configuration")]
public class EnemyConfig : ScriptableObject {
	public float Life;
	public int damageToGoal;
	public bool isDebuffable;
	public float speed;
	public float goldDrop;
}
