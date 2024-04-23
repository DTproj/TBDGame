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

    void Start()
    {
        instance = this;

        dlgOpen = false;
        DialoguePanel.SetActive(false);
    }

    public void EnterDialogue(Dialogue dialogue)
    {
        dlgOpen = true;
        DialoguePanel.SetActive(true);

        if (dialogueQueue.Count == 0)
        {
            ExitDialogue();
        }
    }

    void ExitDialogue()
    {
        dlgOpen = false;
        DialoguePanel?.SetActive(false);
    }
}
