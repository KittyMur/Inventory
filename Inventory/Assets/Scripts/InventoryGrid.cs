using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    private GridLayoutGroup inventoryGrid;
    public GameObject inventoryItem;
    public int Count = 10;
    int index;
    // Start is called before the first frame update
    private void OnEnable()
    {
        DragAndDrop.returnItem += RemoveItem;
    }
    private void OnDisable()
    {
        DragAndDrop.returnItem += RemoveItem;
    }
    void Start()
    {
        inventoryGrid = GetComponent<GridLayoutGroup>();
        AddItem();
    }
    public void AddItem()
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject item = Instantiate(inventoryItem, inventoryGrid.transform);
            index = i;
        }
    }
    public void RemoveItem()
    {

    }
}
