using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : SubsystemUI {


	//public Transform m_itemsParent;
	Inventory m_inventory;
	InventorySlot[] m_slots;
	public List<InventorySlot> slots = new List<InventorySlot>();

	// Use this for initialization
	void Start () {
		m_inventory = Inventory.m_instance;
		m_inventory.onItemChangedCallback += UpdateUI;

		m_slots = m_parent.GetComponentsInChildren<InventorySlot> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void UpdateUI() {
		Debug.Log ("UPDATING UI");
		for (int i = 0; i < m_slots.Length; i++) {
			if (i < m_inventory.m_items.Count)
				m_slots [i].AddItem (m_inventory.m_items [i]);
			else
				m_slots [i].ClearSlot ();
		}
	}
}
