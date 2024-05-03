using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public bool IsDialogueOpen {  get { return dlgOpen; } }

    public GameObject[] Choices;
    public TextMeshProUGUI[] ChoicesText;

    void Start()
    {
        instance = this;

        dlgOpen = false;
        DialoguePanel.SetActive(false);

        dialogueQueue = new Queue<string>();

        ChoicesText = new TextMeshProUGUI[Choices.Length];

        int i = 0;
        foreach (var choice in Choices)
        {
            ChoicesText[i] =choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
    }

    private void ChoiceDisplay()
    {

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
        
        NextLine();
    }

    public void NextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            ExitDialogue();
            return;
        }

        currentLine = dialogueQueue.Dequeue();
        DialogueText.text = currentLine;
    }

    void ExitDialogue()
    {
        dlgOpen = false;
        DialoguePanel.SetActive(false);
    }
}
