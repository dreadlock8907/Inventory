using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour{

    public List<Item> Items;

    public Item getItemByID(int id)
    {
        if (Items.Count == 0)
            return null;

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == id)
            {
                return Items[i];
            }
        }
        return null;
    }
}
