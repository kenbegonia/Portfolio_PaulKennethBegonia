using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoundStart1 : MonoBehaviour {
	public int sceneIndex;

	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene (sceneIndex);
		}
	}
}
