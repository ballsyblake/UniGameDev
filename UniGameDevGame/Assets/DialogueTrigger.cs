using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool dialogueBox;
    public GameObject dialogueBoxUI;

    void Update()
    {
        if (dialogueBox)
        {
            dialogueBoxUI.SetActive(true);
        }
        else
        {
            dialogueBoxUI.SetActive(false);
        }
    }

    public void TriggerDialogue ()
    {
        dialogueBox = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);        
    }

    public void UnTriggerDialogue()
    {
        dialogueBox = false;
    }
}
