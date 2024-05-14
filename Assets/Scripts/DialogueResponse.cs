using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueResponse
{
    [TextArea(3, 10)]
    public string ResponseText;
    public DialogueNode NextNode;
}
