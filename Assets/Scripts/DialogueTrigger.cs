using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private DialogueActor actor;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.EnterDialogue(actor);
    }

}
