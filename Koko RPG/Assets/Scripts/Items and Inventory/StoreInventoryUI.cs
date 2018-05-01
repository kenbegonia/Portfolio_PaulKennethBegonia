using UnityEngine;

public class StoreInventoryUI : MonoBehaviour
{

    public Transform m_itemsParent;
    Inventory m_inventory;
    InventorySlot[] m_slots;

    // Use this for initialization
    void Start()
    {
        m_inventory = Inventory.m_instance;
        m_inventory.onItemChangedCallback += UpdateUI;

        m_slots = m_itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        Debug.Log("UPDATING UI");
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (i < m_inventory.m_items.Count)
                m_slots[i].AddItem(m_inventory.m_items[i]);
            else
                m_slots[i].ClearSlot();
        }
    }
}
