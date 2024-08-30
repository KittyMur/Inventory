using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public static event Action dropItem;
    public static event Action returnItem;
    public Vector2 oldPosition;
    public bool change;
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldPosition = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dropItem?.Invoke();
        if (change)
            transform.position = oldPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        returnItem?.Invoke();
    }
}
