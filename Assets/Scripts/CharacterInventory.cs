using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour {

    public List<CharacterSlot> CharacterSlots;
    public List<ItemData> ItemsOnCharacter;

    private void Start()
    {
        CharacterSlots = new List<CharacterSlot>();
        ItemsOnCharacter = new List<ItemData>();
        AddCharacterSlots();
        addDefaultItemsOnCharacter();
    }

    private void AddCharacterSlots()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            CharacterSlots.Add(this.transform.GetChild(i).GetComponent<CharacterSlot>());
            this.transform.GetChild(i).GetComponent<CharacterSlot>().id = i;
        }       
    }

    private void addDefaultItemsOnCharacter()
    {
        for (int i = 0; i < CharacterSlots.Count; i++)
        {
            ItemsOnCharacter.Add(new ItemData());
            ItemsOnCharacter[i].inventorySlotID = -1;
            ItemsOnCharacter[i].characterSlotID = i;
        }
    }

    public void DeleteItemFromCharacter(int id)
    {
        ItemsOnCharacter[id] = new ItemData();
        ItemsOnCharacter[id].inventorySlotID = -1;
        ItemsOnCharacter[id].characterSlotID = id;
    }

    public Transform GetSlotByType(Item item)
    {
        Transform obj = null;
        for (int i = 0; i < CharacterSlots.Count; i++)
        {
            if (CharacterSlots[i].itemType.Type == item.ItemType.Type)
            {
                switch (item.ItemType.Type)
                {
                    case ItemType.Types.Armor:
                        Armor armor = item as Armor;
                        if (armor.ArmorType.Type == CharacterSlots[i].armorType.Type)
                            obj = CharacterSlots[i].transform;
                        break;
                    case ItemType.Types.Weapon:
                        obj = CharacterSlots[i].transform;
                        break;
                    case ItemType.Types.Shield:
                        obj = CharacterSlots[i].transform;
                        break;
                }
            }
        }
        return obj;
    }

    
}
