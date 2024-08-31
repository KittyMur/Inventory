using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemInList : Item
{
    public ItemData data;
    public Text slotName;
    public Image slotImage;
    RaycastHit2D hit;

    public VerticalLayoutGroup parent;
    GameObject inventoryItem;
    public static event Action detectDelegate;
    // Start is called before the first frame update
    private void OnEnable()
    {
        DragAndDrop.dropItem += PickUpItem;
        DragAndDrop.dropItem += ReturnItem;
        DragAndDrop.returnItem += PickUpItemFromInventory;
    }
    private void OnDisable()
    {
        DragAndDrop.dropItem -= PickUpItem;
        DragAndDrop.dropItem -= ReturnItem;
        DragAndDrop.returnItem += PickUpItemFromInventory;
    }
    // Start is called before the first frame update
    void Start()
    {
        parent = FindObjectOfType<VerticalLayoutGroup>();
        slotName.text = data.ItemName;
        slotImage.sprite = data.ItemImage;
    }
    public override void PickUpItem()
    {
        int mask = LayerMask.GetMask("inventoryItem");
        hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f, mask);

        if (hit.collider != null)
        {
            inventoryItem = hit.collider.gameObject;
            Vector2 inventoryItemSize = inventoryItem.GetComponent<InventoryItem>().ItemSize;
            float inventoryItemCondition = inventoryItem.GetComponent<InventoryItem>().ItemCondition;
            Transform inventoryItemTransform = hit.collider.transform;

            if (inventoryItemCondition == 0 && inventoryItemSize == data.ItemSize)
            {
                transform.SetParent(inventoryItemTransform);
                transform.position = inventoryItemTransform.transform.position;
                GetComponent<DragAndDrop>().change = false;
                detectDelegate?.Invoke();
            }
        }
    }
    public override void ReturnItem()
    {
        if (hit.collider == null)
            GetComponent<DragAndDrop>().change = true;
    }
    public void PickUpItemFromInventory()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.transform == transform)
            {
                transform.SetParent(parent.transform);
            }
        }
    }
}
