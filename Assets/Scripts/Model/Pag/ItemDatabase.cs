using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Global;
public class ItemDatabase : MonoBehaviour {
    public static ItemDatabase instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public Dictionary<int, Item> itemDic = new Dictionary<int, Item>();
    public Dictionary<int, ItemSlot> possessItemDic = new Dictionary<int, ItemSlot>();
    private string itemData;

    // Use this for initialization
    void Start () {
        //获取数据文件路径
        itemData = File.ReadAllText(Application.dataPath + "/Data/Item.txt");
        ConstructItemDatabase();
	}
	
    public void ConstructItemDatabase()
    {
        string str = itemData.ToString();
        string[] strArray = str.Split('\n');

        for(int i = 0; i < strArray.Length; i++)
        {
            string[] proArray = strArray[i].Split('|');
            Item item = new Item();
            item.Id = int.Parse(proArray[0]);
            item.ItemName = proArray[1];
            item.IconName = proArray[3];
            item.Rarity = proArray[2];
            item.Price = int.Parse(proArray[6]);

            switch (proArray[4])
            {
                case "Prop":
                    item.Type = ItemType.Prop;
                    break;
                case "Equipment":
                    item.Type = ItemType.Equipment;
                    break;
            }
            itemDic.Add(item.Id, item);
        }
    }
}
