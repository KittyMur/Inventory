using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InventoryGrid : MonoBehaviour
{
    private GridLayoutGroup inventoryGrid;
    public GameObject[] inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        inventoryGrid = GetComponent<GridLayoutGroup>();
        AddItem();
    }
    public void AddItem()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            GameObject item = Instantiate(inventoryItems[i], inventoryGrid.transform);
            item.GetComponent<InventoryItem>().id = i;
        }
    }
}
