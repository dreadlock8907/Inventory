using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour {

    public Text ItemName;
    public Text ItemDescription;

    private Vector3 _defaultPostion;
    private float _panelSizeX;
    private float _panelSizeY;
    private Dictionary<Item.Rarities, Color32> _palite;


    void Start() {
        ItemInfoHandler.onShowItemInfo += ItemInfoHandler_onShowItemInfo;
        _defaultPostion = this.transform.position;
        _panelSizeX = this.GetComponent<RectTransform>().sizeDelta.x;
        _panelSizeY = this.GetComponent<RectTransform>().sizeDelta.y;

        initPalite();
    }

    private void initPalite()
    {
        _palite = new Dictionary<Item.Rarities, Color32>();

        _palite.Add(Item.Rarities.Common, new Color32(255, 255, 255, 255));
        _palite.Add(Item.Rarities.Uncommon, new Color32(40, 188, 10, 255));
        _palite.Add(Item.Rarities.Rare, new Color32(10, 77, 188, 255));
        _palite.Add(Item.Rarities.Epic, new Color32(157, 90, 255, 255));
    }

    private void ItemInfoHandler_onShowItemInfo(ItemData itemData)
    {
        setPositionToItem(itemData);
        ItemName.text = itemData.item.Name;
        setTextColorByRarity(ItemName, itemData.item.Rare);
        ItemDescription.text = itemData.item.Description;
    }

    private void setPositionToItem(ItemData itemData)
    {
        this.transform.position = itemData.transform.position;
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x - _panelSizeX / 2, this.GetComponent<RectTransform>().anchoredPosition.y - _panelSizeY / 2);
    }

    private void setDefaultPosition()
    {
        this.transform.position = _defaultPostion;
    }

    private void setTextColorByRarity(Text text, Item.Rarities rarity)
    {
        Color32 colorToChange = new Color32();
        _palite.TryGetValue(rarity, out colorToChange);
        text.color = colorToChange;
    }

    public void CloseToolTip()
    {
        setDefaultPosition();
    }

    
}
