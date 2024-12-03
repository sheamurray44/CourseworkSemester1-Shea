using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionsText;
    public int totalNPCs = 11;

    private HashSet<string> interactedNPCs = new HashSet<string>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NPC npc = GetComponent<NPC>();
            if (npc != null)
            {
                InteractWithNPC(npc);
            }
        }
    }

    private void InteractWithNPC(NPC npc)
    {
        if (!interactedNPCs.Contains(npc.npcID))
        {
            interactedNPCs.Add(npc.npcID);
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        interactionsText.text = $"{interactedNPCs.Count}/{totalNPCs} Conversations Had";
    }
}
