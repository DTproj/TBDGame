using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public static DialogueManager Instance { get { return instance; } }

    public GameObject DialoguePanel;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;

    public Button[] Choices;

    private Queue<string> dialogueQueue;
    private bool dlgOpen;
    private string currentLine;

    public bool IsDialogueOpen {  get { return dlgOpen; } }


    void Start()
    {
        instance = this;

        dlgOpen = false;
        DialoguePanel.SetActive(false);

        dialogueQueue = new Queue<string>();

        DisableResponseButtons();
    }

    private void DisableResponseButtons()
    {
        foreach (var btn in Choices)
        {
            btn.enabled = false;
        }
    }

    public void EnterDialogue(DialogueActor actor)
    {
        dlgOpen = true;
        DialoguePanel.SetActive(true);

        DisableResponseButtons();

        NameText.text = actor.Name;

        NextNode(actor.Dialogue.rootNode);
    }

    public void NextNode(DialogueNode node)
    {
        DisableResponseButtons();

        DialogueText.text = node.DialogueText;

        for(int i = 0; i < node.Responses.Count; i++)
        {
            Choices[i].enabled = true;
            Choices[i].GetComponentInChildren<TextMeshProUGUI>().text = node.Responses[i].ResponseText;

            if (node.Responses[i].NextNode == null)
            {
                Choices[i].GetComponent<Button>().onClick.AddListener(() => ExitDialogue());
            }
            else
            {
                Choices[i].GetComponent<Button>().onClick.AddListener(() => NextNode(node.Responses[i].NextNode));
            }           
        }
    }

    void ExitDialogue()
    {
        dlgOpen = false;
        DialoguePanel.SetActive(false);

        //placeholder
        InventoryManager.Instance.AddItemToInventory("Inanimate Item", "It's an inanimate fuckin' item.");
    }

    public void EnterDialogueOld(DialogueActor actor)
    {
        dialogueQueue.Clear();

        dlgOpen = true;
        DialoguePanel.SetActive(true);

        NameText.text = actor.Name;

        foreach (var line in actor.Lines) 
        {
            dialogueQueue.Enqueue(line);
        }
        
        NextLineOld();
    }

    public void NextLineOld()
    {
        if (dialogueQueue.Count == 0)
        {
            ExitDialogue();
            return;
        }

        currentLine = dialogueQueue.Dequeue();
        DialogueText.text = currentLine;
    }
}
