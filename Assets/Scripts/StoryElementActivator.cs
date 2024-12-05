using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElementActivator : MonoBehaviour

    // Using triggers, this script activates the interact button for each npc, allowing the player to trigger their unique dialogue.
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
