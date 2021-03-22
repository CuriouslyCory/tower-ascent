using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Inventory", menuName="Inventory")]
public class Inventory : ScriptableObject
{
    public event EventHandler OnItemListChanged;
    public event EventHandler<StateEventArgs> OnGoldChanged;
    private List<Item> itemList;

    [SerializeField]
    private int _gold;
    public int gold
    {
        get { return _gold; }
        set {
            if(_gold == value)
                return;
            _gold = value;
            OnGoldChanged?.Invoke(this, new StateEventArgs {value = _gold});
        }
    }

    public Inventory() {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable()){
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList){
                if(inventoryItem.itemType == item.itemType){
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if(!itemAlreadyInInventory){
                itemList.Add(item);
            }
        }else{
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public Item GetItemByType(Item.ItemType itemType)
    {
        foreach (Item inventoryItem in itemList){
            if(inventoryItem.itemType == itemType){
                return inventoryItem;
            }
        }
        //Debug.Log("None found");
        // if we didn't find one go ahead and return an empty item of that type
        return new Item{itemType = itemType, amount = 0}; 
    }

    public bool ConsumeItem(Item.ItemType itemType){
        Item usedItem = null;
        foreach (Item inventoryItem in itemList){
            if(inventoryItem.itemType == itemType){
                usedItem = inventoryItem;
                break;
            }
        }
        if(usedItem != null){
            usedItem.amount -= 1;
            if(usedItem.amount < 1){
                itemList.Remove(usedItem);
            }
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        return usedItem != null;
    }
}
