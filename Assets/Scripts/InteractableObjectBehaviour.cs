using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBehaviour : MonoBehaviour
{
    private bool isPlayerClose = false;
    private Color startClr;

    public DlgTrigger dlgTrg;
    public PlayerBehaviour PlayerBehaviourScript;

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
            dlgTrg.TriggerDlg();
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
