using Ink.Runtime;
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

    [SerializeField]
    private GameObject DialoguePanel;

    [SerializeField]
    private TextMeshProUGUI DialogueText;

    [SerializeField]
    private TextMeshProUGUI NameText;

    private bool dlgOpen;
    public bool IsDialogueOpen { get { return dlgOpen; } }

    private Story currentStory;

    void Start()
    {
        instance = this;

        dlgOpen = false;
        DialoguePanel.SetActive(false);
    }

    public void EnterDialogue(DialogueActor actor)
    {
        NameText.text = actor.Name;
        currentStory = new Story(actor.ActorInkJson.text);

        dlgOpen = true;
        DialoguePanel.SetActive(true);

        StoryUpdate();
    }

    public void StoryUpdate()
    {
        if (currentStory.canContinue)
        {
            DialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogue();
        }
    }

    public void ExitDialogue()
    {
        DialoguePanel.SetActive(false);
        dlgOpen = false;
    }
}
