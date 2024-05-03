using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool hasItem;

    private string itemName;
    private string itemDesc;
    public Image Image;

    public void AddItem(string name, string description)
    {
        if (!hasItem)
        {
            itemName = name;
            itemDesc = description;
            hasItem = true;
        }
    }
}
