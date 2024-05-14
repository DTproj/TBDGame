using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueActor
{
    public string Name;

    [TextArea(3, 10)]
    public string[] Lines;

    public DialogueObject Dialogue;
}
