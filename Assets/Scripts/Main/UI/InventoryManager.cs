using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance != null)
            instance = this;
    }
    public TextAsset itemsInfo;

    private Dictionary<int, Item> itemDic = new Dictionary<int, Item>();
    public Dictionary<int, ItemSlot> possessItemDic = new Dictionary<int, ItemSlot>();

	// Use this for initialization
	void Start () {
        ReadItemsInfo();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReadItemsInfo()
    {
        string str = itemsInfo.ToString();
        string[] strArray = str.Split('\n');


        foreach (string s in strArray)
        {
            string[] proArray = s.Split('|');
            Item item = new Item();
            item.id = int.Parse(proArray[0]);
            item.itemName = proArray[1];
            item.iconName = proArray[3];
            item.rarity = proArray[2];
            item.price = int.Parse(proArray[6]);

            switch (proArray[4])
            {
                case "Prop":
                    item.type = ItemType.Prop;
                    break;
                case "Equipment":
                    item.type = ItemType.Equipment;
                    break;
            }
            itemDic.Add(item.id, item);

        }
    }

    public void GetInventoryItems()
    {
        //TODO：连接服务器，获取角色物品
        //随机生成角色物品
        for(int i = 0; i < 25; i++)
        {
            //随机ID
            int id = Random.Range(1001, 1012);
            Item it =null;
            itemDic.TryGetValue(id, out it);
            if(it.type == ItemType.Equipment)
            {
                ItemSlot newItemSlot = new ItemSlot();
                newItemSlot.Count = 1;
                newItemSlot.Item = it;
                possessItemDic.Add(id, newItemSlot);
            }
            else
            {
                ItemSlot itemSlot = null;
                bool isExit = possessItemDic.TryGetValue(id, out itemSlot);
                if(isExit)
                {
                    itemSlot.Count++;
                }
                else
                {
                    ItemSlot newItemSlot = new ItemSlot();
                    newItemSlot.Count = 1;
                    newItemSlot.Item = it;
                }
            }
        }
    }
}
