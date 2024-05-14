using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Object", menuName = "Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public DialogueNode rootNode;
}
