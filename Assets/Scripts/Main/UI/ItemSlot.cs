using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour {
    private Item item;
    private int count;

    public int Count {
        get {
            return count;
        }

        set {
            count = value;
        }
    }

    public Item Item {
        get {
            return item;
        }

        set {
            item = value;
        }
    }
}
