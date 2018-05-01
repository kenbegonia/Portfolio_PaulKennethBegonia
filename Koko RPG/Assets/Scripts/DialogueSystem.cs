using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem m_instance { get; set; }

	public GameObject m_panel;
	Button m_continueButton;
	Text m_dialogueText, m_name;
	int m_dialogueIndex;

	[HideInInspector]
	public List<string> dialogueLines = new List<string> ();
	[HideInInspector]
	public string m_npcName;

	// Use this for initialization
	void Awake () {
		m_continueButton = m_panel.transform.Find ("Continue").GetComponent<Button> ();
		m_dialogueText = m_panel.transform.Find ("Text").GetComponent<Text> ();
		m_name = m_panel.transform.Find ("Name").GetChild (0).GetComponent<Text> ();

		m_panel.SetActive (false);

		m_continueButton.onClick.AddListener (delegate {
			ContinueDialogue();
		});

		if (m_instance != null && m_instance != this)
			Destroy (gameObject);
		else
			m_instance = this;
	}

	public void AddNewDialogue(string[] lines, string npcName) {
		m_dialogueIndex = 0;
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		m_npcName = npcName;

		CreateDialogue ();
	}

	public void CreateDialogue() {
		m_dialogueText.text = dialogueLines [m_dialogueIndex];
		m_name.text = m_npcName;
		m_panel.SetActive (true);
	}

	public void ContinueDialogue() {
		if (m_dialogueIndex < dialogueLines.Count - 1) {
			m_dialogueIndex++;
			m_dialogueText.text = dialogueLines [m_dialogueIndex];
		} else {
			m_panel.SetActive (false);
		}
	}
}
