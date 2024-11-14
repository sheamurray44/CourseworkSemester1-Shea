using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        AudioEventManager.PlaySFX(null, "UI Beep", 0.6f, 1.0f, true, 0.1f, 0f, "UI sound");
    }
}