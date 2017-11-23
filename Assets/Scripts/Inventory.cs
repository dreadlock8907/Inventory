using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public RectTransform slotUIPanel;
    public GameObject inventorySlotPrefab;
    public GameObject inventoryItemPrefab;
    public List<Item> itemsInSlots { set; get; }
    public List<GameObject> inventorySlots { set; get; }

    private InventoryBase _inventoryBase;
    private int _slotsAmount;

    // Use this for initialization
    void Start () {

        itemsInSlots = new List<Item>();
        inventorySlots = new List<GameObject>();
        _slotsAmount = 20;
        _inventoryBase = GetComponent<InventoryBase>();

        AddEmptySlots();
        for (int i = 0; i < _inventoryBase.Items.Count; i++)
        {
            AddItem(i);
        }
    }

    private void AddItem(int id)
    {
        Item targetItem = _inventoryBase.Items[id];
        targetItem.ID = id;
        if (targetItem.Stackable && IsItemInSlot(targetItem))
        {
            for (int i = 0; i < itemsInSlots.Count; i++)
            {
                if (itemsInSlots[i].Name == targetItem.Name)
                {
                    ItemData itemData = inventorySlots[i].transform.GetChild(0).GetComponent<ItemData>();
                    itemData.count++;
                    itemData.GetComponentInChildren<Text>().text = itemData.count.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < itemsInSlots.Count; i++)
            {
                if (itemsInSlots[i].ID == -1)
                {
                    itemsInSlots[i] = targetItem;
                    GameObject gameObj = Instantiate(inventoryItemPrefab);
                    gameObj.GetComponent<ItemData>().item = targetItem;
                    gameObj.transform.SetParent(inventorySlots[i].transform);
                    gameObj.GetComponent<ItemData>().inventorySlotID = inventorySlots[i].GetComponent<Slot>().id;
                    gameObj.transform.position = Vector2.zero;
                    gameObj.transform.localScale = new Vector2(1f, 1f);
                    gameObj.GetComponent<Image>().sprite = targetItem.Sprite;
                    gameObj.name = targetItem.Name;
                    break;
                }
            }
        }
    }

    private void AddEmptySlots()
    {
        for (int i = 0; i < _slotsAmount; i++)
        {
            itemsInSlots.Add(new Item());
            inventorySlots.Add(Instantiate(inventorySlotPrefab));
            inventorySlots[i].transform.GetComponent<Slot>().id = i;
            inventorySlots[i].transform.SetParent(slotUIPanel.gameObject.transform);
            inventorySlots[i].transform.localScale = new Vector2(1f, 1f);
        }
    }

    public bool IsSlotEmpty(int id)
    {

        if (inventorySlots[id].transform.childCount == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool IsItemInSlot(Item item)
    {
        for (int i = 0; i < itemsInSlots.Count; i++)
        {
            if (itemsInSlots[i].Name == item.Name && itemsInSlots[i].ItemType.Type == item.ItemType.Type)
            {
                return true;
            }
        }
        return false;
    }

    public int GetFirstEmptySlot()
    {
        int index = -1;
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].transform.childCount == 0)
            {
                index = i;
                break;
            }
        }
        return index;
    }
}
