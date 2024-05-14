using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueActor actor;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.EnterDialogue(actor);
        //DialogueManager.Instance.EnterDialogueOld(actor);
    }

}
