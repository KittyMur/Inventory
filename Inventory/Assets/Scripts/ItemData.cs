using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Item Data", order = 51)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private float itemCondition;
    [SerializeField]
    private Sprite itemImage;
    [SerializeField]
    private Vector2 itemSize;

    public string ItemName
    {
        get
        {
            return itemName;
        }
    }
    public float ItemCondition
    {
        get
        {
            return itemCondition;
        }
    }
    public Sprite ItemImage
    {
        get
        {
            return itemImage;
        }
    }
    public Vector2 ItemSize
    {
        get
        {
            return itemSize;
        }
    }
}
