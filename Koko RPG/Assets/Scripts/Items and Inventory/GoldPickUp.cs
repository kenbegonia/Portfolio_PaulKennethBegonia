using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : Interactable {

	public GoldItem m_item;
	public int value;

	void Start () {
		m_item.value = value;
	}

	public override void Interact ()
	{
		base.Interact ();

		PickUp ();
	}

	void PickUp () {
		Debug.Log ("Picking up " + m_item.name);
		bool wasPickedUp = m_item.Use();

		if(wasPickedUp)
			Destroy(gameObject);
	}
}
