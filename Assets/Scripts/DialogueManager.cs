using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    private PlayerInteraction playerInteraction;
    void Start()
    {
        sentences = new Queue<string>();
        playerInteraction = GameObject.FindObjectOfType<PlayerInteraction>();
    }

    public void StartDialogue(Dialogue dialogue)
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

    public void DisplayNextSentence()
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

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Interaction.");
        animator.SetBool("IsOpen", false);
        AudioEventManager.PlaySFX(null, "Book Close", 0.7f, 1.0f, true, 0.1f, 0f, "UI sound");
        playerInteraction.UpdateUI();
    }
}
