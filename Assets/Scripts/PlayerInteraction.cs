using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionsText;
    public int totalNPCs = 12;
    public List<string> interactedNPCs = new List<string>();

    private void Awake()
    {
        UpdateUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NPC npc = other.GetComponent<NPC>();
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
        }
    }

    public void UpdateUI()
    {
        interactionsText.text = $"{interactedNPCs.Count}/{totalNPCs} Conversations Had";
    }
}
