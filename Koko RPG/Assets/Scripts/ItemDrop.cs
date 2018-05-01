using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {
	public GameObject[] itemDrops;

	public void ItemDropDeath(Vector3 pos)
	{
		float roll = Random.Range (0f, 101f);
		float probability = 100 / itemDrops.Length;
		float weightSum = 0;

		for (int i = 0; i < itemDrops.Length; i++) {
			weightSum += probability;
			if (roll < weightSum) {
				Instantiate (itemDrops [i], pos, Quaternion.identity);
				Debug.Log ("Dropped");
				return;
			}
		}
	}
}
