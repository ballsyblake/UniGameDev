using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Button dialogueNextBtn;

    public Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	
    public void StartDialogue (Dialogue dialogue)
    {
        dialogueNextBtn.GetComponent<Button>().interactable = true;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueNextBtn.GetComponent<Button>().interactable = false;
    }
	
}
