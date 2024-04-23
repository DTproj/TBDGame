using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBehaviour : MonoBehaviour
{
    private bool isPlayerClose = false;
    private Color startClr;

    public PlayerBehaviour PlayerBehaviourScript;
    public DialogueTrigger DialogueTrigger;

    void Start()
    {
        startClr = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (isPlayerClose)
        {
            DialogueTrigger.TriggerDialogue();
        }
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        CheckDistanceToPlayer();
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startClr;
    }

    void CheckDistanceToPlayer()
    {
        if (Vector3.Distance(transform.position, PlayerBehaviourScript.transform.position) <= 5)
        {
            isPlayerClose = true;
        }
        else
        {
            isPlayerClose = false;
        }
    }
}
