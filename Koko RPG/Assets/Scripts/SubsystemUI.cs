using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsystemUI : MonoBehaviour {

	public Transform m_parent;

	public virtual void UpdateUI() {
		Debug.Log ("UPDATING UI");
	}
}
