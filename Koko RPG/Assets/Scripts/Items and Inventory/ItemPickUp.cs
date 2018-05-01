using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable {

	public Item m_item;

	public override void Interact ()
	{
		base.Interact ();

		PickUp ();
	}

	void PickUp () {
		Debug.Log ("Picking up " + m_item.name);
		bool wasPickedUp = Inventory.m_instance.Add (m_item);

		if(wasPickedUp)
			Destroy(gameObject);
	}
}
