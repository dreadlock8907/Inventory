using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ArmorType {

    public ArmorType(Types type)
    {
        Type = type;
    }
    public Types Type;
    public enum Types
    {
        None,
        Head,
        Chest,
        Gloves,
        Boots
    }
}
