using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;
    public InventorySlot[] InventorySlots;

    private bool isOpen = false;
    public bool IsInventoryOpen {  get { return isOpen; } }

    private static InventoryManager instance;
    public static InventoryManager Instance {  get { return instance; } }

    void Start()
    {
        instance = this;
        Inventory.SetActive(false);
    }

    void Update()
    {
        if (DialogueManager.Instance.IsDialogueOpen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I))
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

    public void DeselectSlots()
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlots[i].selectionShader.SetActive(false);
            InventorySlots[i].isSelected = false;
        }
    }

    public void AddItemToInventory(string name, string description)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (InventorySlots[i].hasItem == false)
            {
                InventorySlots[i].AddItem(name, description);
                return;
            }
        }
    }
}
