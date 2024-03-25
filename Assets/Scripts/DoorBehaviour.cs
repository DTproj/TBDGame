using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Transform PlayerCamera;
    public float InteractDistance;

    private bool IsOpen = false;
    private Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        }
    }
}
