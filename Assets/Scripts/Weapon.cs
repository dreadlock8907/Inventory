using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon", fileName = "Weapon Name")]
public class Weapon : Item {

    [Header("Weapon properties")]
    //public ItemType ItemType = new ItemType(ItemType.Types.Weapon);
    public WeaponType WeaponType;
    [Range(0, 500)]
    public int Power;
    public Mesh Model;

}
