using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";
	public string description = "An item.";
	public Sprite icon = null;
	public bool isDefaultItem = false;
	public Enums.ItemType type;

	public virtual bool Use() {
		Debug.Log ("Using " + name);
		return false;
	}

	//public abstract void Consume ();
}
