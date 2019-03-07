using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotUI : MonoBehaviour {
    private UISprite sprite;

    public UISprite Sprite {
        get {
            if (sprite == null)
                sprite = GetComponent<UISprite>();
            return sprite;
        }

        set {
            sprite = value;
        }
    }

    public void SetSprite(Item item)
    {
        Sprite.enabled = true;
        Sprite.spriteName = item.iconName;
        
    }
}
