using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public bool isElxirPicked = false;
	public Dialogue dialogue;
  
    public void getStatus(bool isEElxirPickd)
    {
		isElxirPicked = isEElxirPickd;
    }


	private void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "player")
		{

			//This Line Triggers Dialogue
			if (isElxirPicked == true)
			{
			
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}
		}
	}
}
