using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("InventoryGO").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (_inventory.IsSlotEmpty(id))
        {
            Debug.Log("OK");
            _inventory.itemsInSlots[droppedItem.inventorySlotID] = new Item();
            _inventory.itemsInSlots[id] = droppedItem.item;
            droppedItem.inventorySlotID = id;
        }
        else
        {
            if (_inventory.inventorySlots[droppedItem.inventorySlotID].transform.childCount != 0)
            {
                Debug.Log("TADAAM");
                _inventory.itemsInSlots[_inventory.GetFirstEmptySlot()] = droppedItem.item;
                droppedItem.inventorySlotID = _inventory.GetFirstEmptySlot();
                droppedItem.transform.SetParent(_inventory.inventorySlots[_inventory.GetFirstEmptySlot()].transform);
                droppedItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            }
            else
            {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().inventorySlotID = droppedItem.inventorySlotID;
                item.transform.SetParent(_inventory.inventorySlots[droppedItem.inventorySlotID].transform);
                item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);

                droppedItem.inventorySlotID = id;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);

                _inventory.itemsInSlots[droppedItem.inventorySlotID] = item.GetComponent<ItemData>().item;
                _inventory.itemsInSlots[id] = droppedItem.item;
            }
        }

        
    }
}
