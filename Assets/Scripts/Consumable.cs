using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable", fileName = "New Consumable")]
public class Consumable : Item {

    [Header("Consumable properties")]
    public ConsumableTypes ConsumableType;
    [Range(0, 20)]
    public int MaxStack;
    public enum ConsumableTypes
    {
        HealtPotion,
        ManaPotion,
        StrenghtPotion,
    }

}
