using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public bool hasItem;
    public bool isSelected;
    public GameObject selectionShader;

    private string itemName;
    private string itemDesc;
    public Image Image;

    void Start()
    {
        selectionShader.SetActive(false);
    }

    public void AddItem(string name, string description)
    {
        if (!hasItem)
        {
            itemName = name;
            itemDesc = description;
            hasItem = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            InventoryManager.Instance.DeselectSlots();
            selectionShader.SetActive(true);
            isSelected = true;

            if (hasItem) 
            {
                DisplayDesc();
            }
            else
            {
                InventoryManager.Instance.DescriptionPanel.SetActive(false);
            }
        }
    }

    private void DisplayDesc()
    { 
        InventoryManager.Instance.DescriptionPanel.SetActive(true);
        InventoryManager.Instance.NameText.text = itemName;
        InventoryManager.Instance.DescriptionText.text = itemDesc;
    }
}
