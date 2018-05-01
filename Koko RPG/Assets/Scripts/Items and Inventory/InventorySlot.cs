
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image m_icon;
	public Button m_removeButton;

	public Text m_itemDescText;

	public AudioClip use;
	public AudioClip flip;
	private AudioSource source;
	public float vol = 3.0f;

	Item m_item;

	void Start() {
		m_itemDescText = GameObject.Find ("Item Description").GetComponentInChildren<Text>();
		source = GetComponentInParent<AudioSource> ();
	}

	public void AddItem(Item newItem) {
		m_item = newItem;
		m_icon.sprite = m_item.icon;
		m_icon.enabled = true;
		m_removeButton.interactable = true;
	}

	public void ClearSlot () {
		m_item = null;

		m_icon.sprite = null;
		m_icon.enabled = false;
		m_removeButton.interactable = false;
	}

	public void OnRemoveButton () {
		Inventory.m_instance.Remove (m_item);
		source.PlayOneShot (flip, vol);
	}

	public void UseItem() {
		if (m_item != null) {
			m_item.Use ();
			source.PlayOneShot (use, vol);
		}
	}

	public void DisplayDescription () {
        if (m_item != null)
        {
            m_itemDescText.text = m_item.description;
        }
	}

	public void ClearDescription () {
		m_itemDescText.text = "Hover on an item to see description.";
	}
}
