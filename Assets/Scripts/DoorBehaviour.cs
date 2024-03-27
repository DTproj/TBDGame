using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    public float RequiredPlayerDistance;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Door")
                {
                    PlayAnimation();
                    isOpen = !isOpen;
                }
            }
        }  
    }

    void PlayAnimation()
    {
        animator = transform.parent.gameObject.GetComponent<Animator>();

        if (isOpen)
        {
            animator.Play("DoorClose");
        }
        else
        {
            animator.Play("DoorOpen");
        }  
    }
}
