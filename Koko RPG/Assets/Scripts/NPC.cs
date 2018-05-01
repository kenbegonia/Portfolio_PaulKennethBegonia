using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
	public string[] m_dialogueLines;
	public string m_name;

	public override void Interact ()
	{
		base.Interact ();
		DialogueSystem.m_instance.AddNewDialogue (m_dialogueLines,m_name);
	}
}
