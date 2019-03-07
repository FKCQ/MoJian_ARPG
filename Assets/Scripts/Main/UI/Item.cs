using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Prop,
    Equipment
}

public class Item {
    public int id;
    public ItemType type;
    public string iconName;
    public string itemName;
    public int price;
    public string rarity;
}
