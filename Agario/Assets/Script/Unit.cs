using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//agar unit type
public enum UnitType
{
	Player,
	Food,
	Enemy,
}

public class Unit : MonoBehaviour {
	public UnitType _type;
}