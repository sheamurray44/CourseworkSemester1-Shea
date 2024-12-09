using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// This script handles the function of keeping track of the interactions that the player has engaged with, and updating the UI to show this.
/// </summary>

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionsText;
    public TextMeshProUGUI updateText;
    public GameObject progressText;
    public GameObject finishText;
    public int totalNPCs = 12;
    public List<string> interactedNPCs = new List<string>();

    private void Awake() // UI immediately updates to show 0/12 NPCs spoken with
    {
        UpdateUI();
    }
    private void OnTriggerEnter(Collider other) // This gunction will count an NPC as interacted with and add it to the list of NPCs spoken too, preventing multiple updates when interaced with multiple times
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

    public void UpdateUI() // This method is to have the tracker in the UI be accurate. It contains a coroutine that adds progression as players engage with NPCs
    {
        interactionsText.text = $"{interactedNPCs.Count}/{totalNPCs} Conversations Had";

        if (interactedNPCs.Count > 6 && progressText == true)
        {
            StartCoroutine(ProgressUpdate());
        }
        if (interactedNPCs.Count == 12)
        {
            FinishGame();
        }
    }

    public IEnumerator ProgressUpdate() // A UI element that updates the players when they're about half way through the game.
    {
        updateText.text = $"{totalNPCs - interactedNPCs.Count} Conversations Remaining. Keep Searching.";
        progressText.SetActive(true);
        AudioEventManager.PlaySFX(null, "Sine Beep", 0.7f, 1.0f, true, 0.1f, 0f, "UI sound");
        yield return new WaitForSeconds(4);
        progressText.SetActive(false);
        AudioEventManager.PlaySFX(null, "Sine Beep", 0.7f, 1.0f, true, 0.1f, 0f, "UI sound");
    }

    private void FinishGame() // A method that enables the end of game UI elements
    {
        finishText.SetActive(true);
    }

    public void RestartGame() // The method for restarting the scene is stored here, the button is part of the end of game UI and allows for game restart with OnClick events.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
