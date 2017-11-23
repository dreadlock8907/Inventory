using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMenuSwitcher : MonoBehaviour, IPointerClickHandler {

    public Transform InventoryUI;
    public Transform CharacterUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        SwitchInventoryUI();
    }

    public void SwitchInventoryUI()
    {
        InventoryUI.gameObject.SetActive(!InventoryUI.gameObject.activeSelf);
        CharacterUI.gameObject.SetActive(!CharacterUI.gameObject.activeSelf);
    }

}
