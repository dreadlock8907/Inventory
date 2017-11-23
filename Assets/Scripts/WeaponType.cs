using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponType {

    public WeaponType(Types type)
    {
        Type = type;
    }

    public Types Type;
    public enum Types
    {
        None,
        Staff,
        Sword,
        Axe,
        Mace
    }

}
