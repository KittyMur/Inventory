using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class InventoryItem : Item, ISave
{
    public Vector2 ItemSize;
    public int ItemCondition = 0;
    public int id;
    int idToJson;
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
    void Start()
    {
        LoadData();
    }
    public override void PickUpItem()
    {
        if (GetComponentInChildren<ItemInList>() != null)
        {
            ItemCondition = 1;
            ItemInList item = GetComponentInChildren<ItemInList>();
            ItemData data = item.data;
            childName = data.name;
            idToJson = id;
            SaveData();
        }
        else ItemCondition = 0;
    }
    public override void ReturnItem()
    {
        if (GetComponentInChildren<ItemInList>() == null)
        {
            ItemCondition = 0;
            idToJson = -1;
            childName = null;
            IDinventoryItem idItem = new IDinventoryItem(idToJson, childName);
            File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(idItem));
        }
        else ItemCondition = 1;
    }

    public void SaveData()
    {
        IDinventoryItem idItem = new IDinventoryItem(idToJson, childName);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.transform.position == transform.position)
            {
                File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(idItem));
            }
        }
    }
    public void LoadData()
    {
        IDinventoryItem idItem = JsonUtility.FromJson<IDinventoryItem>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
        if (idItem.Id == id)
        {
            ItemInList[] temsInList= Resources.LoadAll<ItemInList>("prefabs");
            foreach (ItemInList itemInList in temsInList)
            {
                if (itemInList.data.name == idItem.Name)
                {
                    Instantiate(itemInList, transform);
                }    
            }
        }
    }
}
