using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item/CommonItem", fileName = "Common file name")]
public class Item : ScriptableObject {

    [Header("Common properties")]
    public string Name = "Name of the item";
    public Rarities Rare;
    [Multiline(3)]
    public string Description = "Item's description";
    public Sprite Sprite;
    public bool Stackable;
    public ItemType ItemType;

    [HideInInspector]
    public int ID;
    public Item()
    {
        ID = -1;
    }

    public enum Rarities
    {
        Common,
        Uncommon,
        Rare,
        Epic
    }

}
