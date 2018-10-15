using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour {

    private GameObject player;
    private float distance;
    private DialogueTrigger trigger;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        trigger = gameObject.GetComponent<DialogueTrigger>();
	}

    private void Update()
    {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance <= 5f)
            trigger.TriggerDialogue();
    }
}
