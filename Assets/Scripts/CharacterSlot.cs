using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot : MonoBehaviour
{
    public int id;
    public ItemType itemType;
    public ArmorType armorType;
    public WeaponType weapon;

    private Inventory _inventory;
    private CharacterInventory _characterInventory;

    public delegate void ItemWeared(ItemData itemData);
    public static event ItemWeared onItemWeared;

    public delegate void ItemUnweared(ItemData itemData);
    public static event ItemUnweared onItemUnweared;


    private void Start()
    {
        ItemData.onItemDropped += ItemInfo_onItemDropped;
        ItemData.onItemStartDragging += ItemInfo_onItemStartDragging;
        _inventory = GameObject.FindGameObjectWithTag("InventoryGO").GetComponent<Inventory>();
        _characterInventory = this.transform.parent.GetComponent<CharacterInventory>();
    }

    private void ItemInfo_onItemStartDragging(ItemData item)
    {
        Debug.Log("START DRAGGED");
        _characterInventory.DeleteItemFromCharacter(item.characterSlotID);

        if (onItemUnweared != null)
        {
            onItemUnweared(item);
        }
    }

    private void ItemInfo_onItemDropped(Transform slot, ItemData item)
    {
        if (slot.gameObject == this.gameObject)
        {
            
            if (_characterInventory.ItemsOnCharacter[id].inventorySlotID == -1)
            {
                Debug.Log("COMPLEX!");
                _characterInventory.ItemsOnCharacter[id] = item;
                _inventory.itemsInSlots[item.inventorySlotID] = new Item();
                item.characterSlotID = id;
            }
            else
            {
                Debug.Log("ANOTHER");
                Transform previousItem = this.transform.GetChild(0);
                _inventory.itemsInSlots[item.inventorySlotID] = _characterInventory.ItemsOnCharacter[id].item;
                previousItem.SetParent(_inventory.inventorySlots[item.inventorySlotID].transform);
                previousItem.GetComponent<ItemData>().inventorySlotID = item.inventorySlotID;
                previousItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
                item.characterSlotID = id;
                _characterInventory.ItemsOnCharacter[id] = item;
            }

            if (onItemWeared != null)
            {
                onItemWeared(item);
            }

        }
    }

}