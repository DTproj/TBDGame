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

    [SerializeField]
    private GameObject[] Choices;
    private TextMeshProUGUI[] ChoicesTexts;

    private bool dlgOpen;
    public bool IsDialogueOpen { get { return dlgOpen; } }

    private Story currentStory;

    void Start()
    {
        instance = this;

        dlgOpen = false;
        DialoguePanel.SetActive(false);

        ChoicesTexts = new TextMeshProUGUI[Choices.Length];

        for (int i = 0; i < Choices.Length; i++)
        {
            ChoicesTexts[i] = Choices[i].GetComponentInChildren<TextMeshProUGUI>(); 
        }
    }

    public void EnterDialogue(DialogueActor actor)
    {
        NameText.text = actor.Name;
        currentStory = new Story(actor.ActorInkJson.text);

        dlgOpen = true;
        DialoguePanel.SetActive(true);

        StoryUpdate();
    }

    private void StoryUpdate()
    {
        if (currentStory.canContinue)
        {
            DialogueText.text = currentStory.Continue();
            ChoiceDisplay();
        }
        else
        {
            ExitDialogue();
        }
    }

    private void ChoiceDisplay()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        int j = 0;

        for (int i = 0; i < currentChoices.Count; i++)
        {
            Choices[i].SetActive(true);
            ChoicesTexts[i].text = Choices[i].GetComponentInChildren<TextMeshProUGUI>().text;
            j = i;
        }

        for (int i = j; i < Choices.Length; i++)
        {
            Choices[i].SetActive(false);
        }
    }

    private void ExitDialogue()
    {
        DialoguePanel.SetActive(false);
        dlgOpen = false;
    }
}
