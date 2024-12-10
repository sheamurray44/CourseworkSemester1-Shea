using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Dialogue manager script that handles the starting, stopping, next sentence, character typing and UI implementation of the dialogue.
/// </summary>

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    private PlayerInteraction playerInteraction;

    private void Awake() // Queue and playerinteraction script initialised in Start
    {
        sentences = new Queue<string>();
        playerInteraction = GameObject.FindObjectOfType<PlayerInteraction>();
    }

    public void StartDialogue(Dialogue dialogue) // Method that starts the dialogue and shows the text box, queues the next sentence and displays the next one on click of the continue button.
    {
        Debug.Log("Interacting with " + dialogue.name);
        animator.SetBool("IsOpen", true);
        AudioEventManager.PlaySFX(null, "Book Open", 0.7f, 1.0f, true, 0.1f, 0f, "UI sound");
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void DisplayNextSentence() // Handles showing the next sentence in the queue and calls the end dialogue method
    {
        AudioEventManager.PlaySFX(null, "UI Beep", 0.6f, 1.0f, true, 0.1f, 0f, "UI sound");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence) // Individually types out each character in the dialogue box.
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void EndDialogue() // Animates the text box to move away and starts the Tracker Delay coroutine
    {
        Debug.Log("End of Interaction.");
        animator.SetBool("IsOpen", false);
        AudioEventManager.PlaySFX(null, "Book Close", 0.7f, 1.0f, true, 0.1f, 0f, "UI sound");
        StartCoroutine(TrackerDelay());
    }

    private IEnumerator TrackerDelay() // Responsible for adding a small delay to the update of the interaction tracker in the UI. Calls te updateUI method from playerinteracton.
    {
        yield return new WaitForSeconds(1.25f);
        playerInteraction.UpdateUI();
        AudioEventManager.PlaySFX(null, "Notification sound 18", 0.7f, 1.0f, true, 0.1f, 0f, "UI sound");
    }
}
