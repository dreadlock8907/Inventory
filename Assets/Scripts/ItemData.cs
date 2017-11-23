using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Item item;
    public int count = 1;
    public int characterSlotID;
    public int inventorySlotID;

    private Vector2 _offset;
    private Inventory _inventory;
    private CharacterInventory _characterInventory;
    private Transform _slotsPanel;

    public delegate void ItemDropped(Transform slot, ItemData itemData);
    public static event ItemDropped onItemDropped;

    public delegate void ItemBeginDrag(ItemData itemData);
    public static event ItemBeginDrag onItemStartDragging;


    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("InventoryGO").GetComponent<Inventory>();
        _characterInventory = GameObject.FindGameObjectWithTag("CharacterInfo").GetComponent<CharacterInventory>();
        _slotsPanel = GameObject.FindGameObjectWithTag("SlotsPanel").GetComponent<Transform>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            _offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);

            this.transform.SetParent(this.transform.parent.parent.parent.parent);
            this.transform.position = eventData.position - _offset;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;

            if (eventData.hovered.Contains(_characterInventory.gameObject))
            {
                if (onItemStartDragging != null)
                {
                    onItemStartDragging(eventData.pointerDrag.GetComponent<ItemData>());
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - _offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("One");
            if (isDragOnCharacterInventory(eventData) && item.ItemType.Type != ItemType.Types.Consumable)
            {
                Debug.Log("Two");
                this.transform.SetParent(_characterInventory.GetSlotByType(item));
                this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
                this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                if (onItemDropped != null)
                {
                    onItemDropped(_characterInventory.GetSlotByType(item), this);
                }
            }
            else
            {
                try
                {
                    this.transform.SetParent(_inventory.inventorySlots[inventorySlotID].transform);
                    Debug.Log("Three");
                    this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
                    this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                catch
                {
                    Debug.Log("somethig gonna wrong..");
                }
            }
        }

    }

    private bool isDragOnCharacterInventory(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "CharacterImage")
            {
                Debug.Log("Var0");
                return true;
            }
            else if (eventData.pointerCurrentRaycast.gameObject == _characterInventory.gameObject)
            {
                Debug.Log("Var1");
                return true;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CharacterSlot>() != null)
            {
                Debug.Log("Var2");
                return true;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<CharacterSlot>() != null)
            {
                Debug.Log("Var3");
                return true;
            }
            else
            {
                Debug.Log("Var4");
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
