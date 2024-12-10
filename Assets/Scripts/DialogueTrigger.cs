using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to be attached to UI elements containing the dialogue. The dialogue lines are written here. The TriggerDialogue method here is called in the UI OnClick events on an interact button that begins the NPC interactions.
/// </summary>

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // Reference to the dialogue class - allows lines to be written.
    private DialogueManager dialogueManager; 

    private void Awake()  // Dialogue Manager is found during Awake only once isntead of each time the dialogue is triggered in the method below - optomised and good practise.
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void TriggerDialogue() // Start dialogue method is called here from the manager
    {
        dialogueManager.StartDialogue(dialogue);
    }
}