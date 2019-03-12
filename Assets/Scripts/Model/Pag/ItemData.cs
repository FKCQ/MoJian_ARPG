using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子中的物品
/// </summary>
public class ItemData : MonoBehaviour {
    private int slotId;
    private int amount;
    private Item item;

    public delegate void OnAmountChange();
    public event OnAmountChange onAmountChangeEvent;

    public int SlotId {
        get {
            return slotId;
        }

        set {
            slotId = value;
        }
    }

    public int Amount {
        get {
            return amount;
        }

        set {
            amount = value;
            if(onAmountChangeEvent != null)
                onAmountChangeEvent.Invoke();
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
