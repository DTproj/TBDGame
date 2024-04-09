using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    private bool isPlayerClose = false;
    private Color startClr;

    public PlayerBehaviour PlayerBehaviourScript;

    void Start()
    {
        startClr = GetComponent<Renderer>().material.color;
        animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Door" && isPlayerClose)
                {
                    PlayAnimation();
                    isOpen = !isOpen;
                }
            }
        }  
    }

    void PlayAnimation()
    {
        if (isOpen)
        {
            animator.Play("DoorClose");
        }
        else
        {
            animator.Play("DoorOpen");
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
        if(Vector3.Distance(transform.position, PlayerBehaviourScript.transform.position) <= 5)
        {
            isPlayerClose = true;
        }
        else
        {
            isPlayerClose = false;
        }
    }
}
