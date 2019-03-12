using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_ItemDisplay : MonoBehaviour {
    private ItemData itemData;
    private UISprite sprite;
    private UILabel label;
    private UIButton button;
    private void OnEnable()
    {
        itemData = GetComponentInChildren<ItemData>();
        label = transform.Find("Label").GetComponent<UILabel>();
        sprite = transform.Find("Sprite").GetComponent<UISprite>();
        button = sprite.GetComponent<UIButton>();
        itemData.onAmountChangeEvent += UpdateUI;
    }

    private void UpdateUI()
    {
        if (itemData.Amount != 0)
        {
            if(itemData.Amount > 1)
                label.text = itemData.Amount.ToString();
            sprite.enabled = true;
            sprite.spriteName = itemData.Item.IconName;
            button.normalSprite = sprite.spriteName;
        }
        else
        {
            label.text = string.Empty;
            sprite.enabled = false;
        }
    }
}
