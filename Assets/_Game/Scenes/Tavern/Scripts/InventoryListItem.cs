using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class InventoryListItem : MonoBehaviour
{
    private InventorySlot inventorySlot;
    
    [SerializeField]
    private Image image;
    
    [SerializeField]
    private TextMeshProUGUI text;
    
    [SerializeField]
    private Image equippedItem;

    private Button_UI button;

    [SerializeField]
    private TextMeshProUGUI quantityText;

    public void SetItem(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;
    
        this.image.sprite = inventorySlot.item.sprite;
        this.text.text = inventorySlot.item.itemName;
        this.button = GetComponent<Button_UI>();

        if(inventorySlot.item.IsStackable()){
            quantityText.enabled = true;
            quantityText.text = inventorySlot.quantity.ToString();
        }
        equippedItem.enabled = inventorySlot.isEquipped;

        button.ClickFunc = () => {
            EquipItem(inventorySlot);
        };
    }

    private void EquipItem(InventorySlot inventorySlot){
        GameAssets.i.gameState.inventory.EquipItem(inventorySlot);
        equippedItem.enabled = inventorySlot.isEquipped;
    }
}
