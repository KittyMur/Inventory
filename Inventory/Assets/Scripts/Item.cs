using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void PickUpItem();
    public abstract void ReturnItem();
}
