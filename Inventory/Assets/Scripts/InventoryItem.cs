using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryItem : Item
{
    public Vector2 ItemSize;
    public int ItemCondition = 0;
    string childName;
    private void OnEnable()
    {
        ItemInList.detectDelegate += PickUpItem;
        DragAndDrop.returnItem += ReturnItem;
    }
    private void OnDisable()
    {
        ItemInList.detectDelegate -= PickUpItem;
        DragAndDrop.returnItem -= ReturnItem;
    }
    public override void PickUpItem()
    {
        if (GetComponentInChildren<ItemInList>() != null)
            ItemCondition = 1;
        else ItemCondition = 0;
    }

    public override void ReturnItem()
    {
        if (GetComponentInChildren<ItemInList>() == null)
            ItemCondition = 0;
        else ItemCondition = 1;
    }

}
