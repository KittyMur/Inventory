using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public ItemInList[] ListItem;
    VerticalLayoutGroup ListGrid;
    int Count;
    int maxCount = 0;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ListGrid = GetComponentInChildren<VerticalLayoutGroup>();
    }
    void Start()
    {
        ListItem = Resources.LoadAll<ItemInList>("prefabs");
        Count = 15;
        while (maxCount < Count)
        {
            AddItem();
        }
    }
    public void AddItem()
    {
        int randomId = Random.Range(0, ListItem.Length);
        Instantiate(ListItem[randomId], ListGrid.transform);
        maxCount++;
    }
}
