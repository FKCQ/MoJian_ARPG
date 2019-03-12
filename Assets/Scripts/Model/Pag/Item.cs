using Global;

public class Item {
    private int id;
    private ItemType type;
    private string iconName;
    private string itemName;
    private string description;
    private int price;
    private string rarity;

    #region 属性
    public int Id {
        get {
            return id;
        }

        set {
            id = value;
        }
    }

    public ItemType Type {
        get {
            return type;
        }

        set {
            type = value;
        }
    }

    public string IconName {
        get {
            return iconName;
        }

        set {
            iconName = value;
        }
    }

    public string ItemName {
        get {
            return itemName;
        }

        set {
            itemName = value;
        }
    }

    public int Price {
        get {
            return price;
        }

        set {
            price = value;
        }
    }

    public string Rarity {
        get {
            return rarity;
        }

        set {
            rarity = value;
        }
    }

    public string Description {
        get {
            return description;
        }

        set {
            description = value;
        }
    }
    #endregion

}
