using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class Inventory : MonoBehaviour
{

    public ItemSlot[] itemSlots;
    private ItemDatabase database;
    private List<ItemData> items = new List<ItemData>();                //存放拥有的item数据

    private void Start()
    {
        database = GetComponent<ItemDatabase>();
        itemSlots = GetComponentsInChildren<ItemSlot>();

        ItemData itemData = null;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].Id = i;
            //获取格子下的物品
            itemData = itemSlots[i].GetComponentInChildren<ItemData>();
            items.Add(itemData);
        }
        AddItem(1001);
        AddItem(1002);
        AddItem(1003);
    }

    private void Update()
    {
        //按下G获得装备
        if(Input.GetKeyDown(KeyCode.G))
        {
            int index = Random.Range(1001, 1012);
            AddItem(index);
        }
    }
    /// <summary>
    /// 将物体加入到格子中
    /// </summary>
    /// <param name="id"></param>
    public void AddItem(int id)
    {
        Item item;
        database.itemDic.TryGetValue(id, out item);
       
        if(item != null && CheckIfItemIsInSlots(item) && item.Type == ItemType.Prop)
        {
            for(int i = 0; i < items.Count; i++)
            {
                //找到相同item所在位置
                if(id == items[i].Item.Id)
                {
                    items[i].Amount++;
                    break;
                }
            }
        }
        else
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(items[i].Amount == 0)
                {
                    items[i].Item = item;
                    items[i].Amount++;
                    break;
                }
            }
        }
        
    }

    /// <summary>
    /// 判断是否拥有相同的item
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool CheckIfItemIsInSlots(Item item)
    {
        for(int i = 0; i < items.Count;i++)
        {
            //如果当前格子没有物品
            if (items[i].Item == null)
                continue;

            if (item.Id == items[i].Item.Id)
                return true;
        }
        return false;
    }

}