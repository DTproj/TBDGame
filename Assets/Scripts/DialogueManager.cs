using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public static DialogueManager Instance { get { return instance; } }

    public GameObject DialoguePanel;
    public TextMeshProUGUI DialogueText;

    private Queue<string> dialogueQueue;
    private bool dlgOpen;
    private string currentLine;

    void Start()
    {
        instance = this;

        dlgOpen = false;
        DialoguePanel.SetActive(false);

        dialogueQueue = new Queue<string>();
    }

    public void EnterDialogue(Dialogue dialogue)
    {
        dialogueQueue.Clear();

        dlgOpen = true;
        DialoguePanel.SetActive(true);

        foreach (var line in dialogue.Lines) 
        {
            dialogueQueue.Enqueue(line);
        }      
    }

    public void NextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            ExitDialogue();
        }

        currentLine = dialogueQueue.Dequeue();
    }

    void ExitDialogue()
    {
        dlgOpen = false;
        DialoguePanel.SetActive(false);
    }
}
