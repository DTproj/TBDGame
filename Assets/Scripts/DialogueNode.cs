using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueNode
{
    [TextArea(3, 10)]
    public string DialogueText;
    public List<DialogueResponse> Responses;
}
