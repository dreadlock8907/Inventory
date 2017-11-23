using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour {

    public Transform RightHand;
    public Transform LeftHand;
    public Transform Head;
    public Transform Body;

    private Dictionary<ItemType.Types, Transform> _charactersAmmo;
    private Dictionary<ArmorType.Types, Transform> _charactersEquip;

	void Start () {

        CharacterSlot.onItemWeared += CharacterSlot_onItemWeared;
        CharacterSlot.onItemUnweared += CharacterSlot_onItemUnweared;
        initCharactersParts();
    }

    private void initCharactersParts()
    {
        _charactersAmmo = new Dictionary<ItemType.Types, Transform>();
        _charactersAmmo.Add(ItemType.Types.Weapon, RightHand);
        _charactersAmmo.Add(ItemType.Types.Shield, LeftHand);

        _charactersEquip = new Dictionary<ArmorType.Types, Transform>();
        _charactersEquip.Add(ArmorType.Types.Chest, Body);
        _charactersEquip.Add(ArmorType.Types.Head, Head);
    }

    private void CharacterSlot_onItemUnweared(ItemData itemData)
    {
        equipByType(itemData.item, false);
    }

    private void CharacterSlot_onItemWeared(ItemData itemData)
    {
        equipByType(itemData.item, true);
    }

    private void equipByType(Item item, bool needEquip)
    {
        Transform obj = null;

        switch (item.ItemType.Type)
        {
            case ItemType.Types.Armor:
                Armor armor = item as Armor;
                _charactersEquip.TryGetValue(armor.ArmorType.Type, out obj);
                if (needEquip)
                    obj.GetChild(0).GetComponent<MeshFilter>().mesh = armor.Model;
                else
                    obj.GetChild(0).GetComponent<MeshFilter>().mesh = null;
                break;
            case ItemType.Types.Weapon:
                Weapon weapon = item as Weapon;
                _charactersAmmo.TryGetValue(item.ItemType.Type, out obj);
                if (needEquip)
                    obj.GetChild(0).GetComponent<MeshFilter>().mesh = weapon.Model;
                else
                    obj.GetChild(0).GetComponent<MeshFilter>().mesh = null;
                break;
            case ItemType.Types.Shield:
                Shield shield = item as Shield;
                _charactersAmmo.TryGetValue(item.ItemType.Type, out obj);
                if (needEquip)
                    obj.GetChild(0).GetComponent<MeshFilter>().mesh = shield.Model;
                else
                    obj.GetChild(0).GetComponent<MeshFilter>().mesh = null;
                break;
        }
    }

}
