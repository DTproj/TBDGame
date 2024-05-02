using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;

    private bool isOpen = false;

    void Start()
    {
        Inventory.SetActive(false);
    }

    void Update()
    {
        if (DialogueManager.Instance.IsDialogueOpen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
            {
                Inventory.SetActive(false);
                isOpen = false;
            }
            else
            {
                Inventory.SetActive(true);
                isOpen = true;
            }
        }
    }
}
