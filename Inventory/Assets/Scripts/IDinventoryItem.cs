using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

[Serializable]
public class IDinventoryItem 
{
    public int Id;
    public string Name;

    public IDinventoryItem(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
