using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemType {

    public ItemType(Types type)
    {
        Type = type;
    }
    public Types Type;

    public enum Types
    {
        Armor,
        Weapon,
        Shield,
        Consumable
    }
}
