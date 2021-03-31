using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{
    private Item item;

    public void SetItem(Item item, bool sell = false, InventorySlot inventorySlot = null)
    {
        this.item = item;
        int price = sell ? item.price / 3 : item.price;
        string qtyPrefix = inventorySlot != null ? inventorySlot.quantity + "x " : "";
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = qtyPrefix + item.itemName;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = price.ToString()+"G";
    }

}
