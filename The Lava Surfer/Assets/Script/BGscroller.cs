using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class BGscroller : MonoBehaviour {
	public float scrollSpeed = 1.5f;

	void Update () 
	{
		Vector2 scrollOffset = new Vector2 (Time.time * scrollSpeed, 0);

		GetComponent<Renderer> ().material.mainTextureOffset = scrollOffset;
	}
}
