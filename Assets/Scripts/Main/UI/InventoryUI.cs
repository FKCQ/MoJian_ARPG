using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public Transform itemSlotParent;
    public ItemSlot[] itemSlots;

    private InventoryManager inventoryManager;
    // Use this for initialization
    void Start () {
        inventoryManager = InventoryManager.instance;
        itemSlots = itemSlotParent.GetComponentsInChildren<ItemSlot>();

	}

    public void UpdateUI()
    {
        for(int i = 0; i < inventoryManager.possessItemDic.Count; i++)
        {

        }
    }

}
