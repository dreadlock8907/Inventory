using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoHandler : MonoBehaviour {

    private ItemData _itemData;

    public delegate void ShowItemInfo(ItemData itemData);
    public static event ShowItemInfo onShowItemInfo;

    private void Start()
    {
        _itemData = this.GetComponent<ItemData>();
    }

    public void ShowInfo()
    {
        if (onShowItemInfo != null)
        {
            onShowItemInfo(_itemData);
        }
    }
}
