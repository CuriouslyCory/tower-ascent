using System;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class SellItemShop : MonoBehaviour
{
    [SerializeField]
    private GameObject pfSellButton;

    private List<GameObject> buttonObjs;

    private Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameAssets.i.gameState.inventory;
        buttonObjs = new List<GameObject>();
        
        GenerateSellMenu();
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void OnDestroy() {
        inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    private void GenerateSellMenu()
    {
        ClearSellMenu();
        List<InventorySlot> inventorySlots = inventory.inventorySlots;
        foreach(InventorySlot inventorySlot in inventorySlots){
            if(!inventorySlot.isEquipped){
                CreateShopButton(inventorySlot);
            }
        }
    }

    private void ClearSellMenu()
    {
        if(buttonObjs.Count > 0){
            foreach(GameObject button in buttonObjs){
                Destroy(button);
            }
        }
    }

    private void CreateShopButton(InventorySlot inventorySlot)
    {
        buttonObjs.Add(Instantiate(pfSellButton, transform));
        buttonObjs[buttonObjs.Count - 1].GetComponent<ShopButton>().SetItem(inventorySlot.item, true, inventorySlot);
        
        buttonObjs[buttonObjs.Count - 1].GetComponent<Button_UI>().ClickFunc = () => {
            SellItem(inventorySlot);
        };
    }

    public void SellItem(InventorySlot inventorySlot)
    {
        inventory.SellItem(inventorySlot);
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        GenerateSellMenu();
    }
}
