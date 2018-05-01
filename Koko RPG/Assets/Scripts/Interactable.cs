using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public float m_radius = 3f;
	bool m_isFocus = false;
	bool m_hasInteracted = false;

	public Transform interactionTransform;
	Transform m_player;




	public virtual void Interact() {
		Debug.Log ("Interacting with " + transform.name);

	}

	void Update () {
		if (m_isFocus && !m_hasInteracted) {
			float distance = Vector3.Distance (m_player.position, interactionTransform.position);
			if (distance <= m_radius) {
				Interact ();
				m_hasInteracted = true;
			}
			else {
				m_hasInteracted = false;
				m_isFocus = false;
			}
		}
	}

	public void OnFocused (Transform playerTransform) {
		m_isFocus = true;
		m_player = playerTransform;
		m_hasInteracted = false;
	}

	public void OnDefocused () {
		m_isFocus = false;
		m_player = null;
		m_hasInteracted = false;
	}

	void OnDrawGizmosSelected () {
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position, m_radius);
	}
}
