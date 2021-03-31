using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject pfInventoryListItem;
    private Inventory inventory;

    private List<GameObject> inventoryListItems = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameAssets.i.gameState.inventory;
        GenerateInventoryList();
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void OnDestroy() {
        inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    private void GenerateInventoryList()
    {
        ClearList();
        List<InventorySlot> inventorySlots = inventory.inventorySlots;
        foreach(InventorySlot inventorySlot in inventorySlots){
            CreateListItem(inventorySlot);
        }
    }

    private void CreateListItem(InventorySlot inventorySlot)
    {
        inventoryListItems.Add(Instantiate(pfInventoryListItem, transform));
        inventoryListItems[inventoryListItems.Count - 1].GetComponent<InventoryListItem>().SetItem(inventorySlot);
    }


    private void ClearList()
    {
        if(inventoryListItems.Count > 0){
            foreach(GameObject listItem in inventoryListItems){
                Destroy(listItem);
            }
        }
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        GenerateInventoryList();
    }
}
