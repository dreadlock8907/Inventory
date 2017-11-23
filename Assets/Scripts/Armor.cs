using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Armor", fileName = "Armor Name")]
public class Armor : Item {

    [Header("Armor propeties")]
    //public ItemType ItemType = new ItemType(ItemType.Types.Armor);
    public ArmorType ArmorType;
    [Range(0, 100)]
    public int Defence;
    public Mesh Model;

}
