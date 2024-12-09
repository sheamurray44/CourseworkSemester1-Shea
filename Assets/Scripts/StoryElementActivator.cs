using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Using triggers, this script activates the interact button for each npc, allowing the player to trigger their unique dialogue.
/// </summary>

public class StoryElementActivator : MonoBehaviour

{
    public GameObject interactButton;

    private void OnTriggerEnter(Collider other)
    {
        interactButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactButton.SetActive(false);
    }
}
