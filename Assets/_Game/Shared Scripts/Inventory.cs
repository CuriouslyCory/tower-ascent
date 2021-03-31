using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="New Inventory", menuName="Inventory System")]
[Serializable]
public class Inventory : ScriptableObject
{
    public event EventHandler OnItemListChanged;
    public event EventHandler<StateEventArgs> OnGoldChanged;
    
    [SerializeField]
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

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
        // itemList = new List<Item>();
    }

    public void AddItem(Item item, int quantity)
    {
        if(item.IsStackable()){
            InventorySlot inventorySlot = inventorySlots.Find(inventorySlot => inventorySlot.item.itemName == item.itemName);
            if(inventorySlot != null){
                inventorySlot.quantity += quantity;
            }else{
                inventorySlots.Add(new InventorySlot(item, quantity));
            }
        }else{
            inventorySlots.Add(new InventorySlot(item, quantity));
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public InventorySlot GetInventorySlotByType(Item.ItemType itemType)
    {
        return inventorySlots.Find(inventorySlot => inventorySlot.item.itemType == itemType);
    }

    public bool ConsumeItem(Item.ItemType itemType){
        InventorySlot inventorySlot = inventorySlots.Find(inventorySlot => inventorySlot.item.itemType == itemType);
        if(inventorySlot != null){
            inventorySlot.quantity -= 1;
            if(inventorySlot.quantity < 1){
                inventorySlots.Remove(inventorySlot);
            }
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
        return inventorySlot != null;
    }

    public bool SellItem(InventorySlot inventorySlot){
        gold += inventorySlot.item.price / 3;
        if(inventorySlot != null){
            inventorySlot.quantity -= 1;
            if(inventorySlot.quantity < 1){
                inventorySlots.Remove(inventorySlot);
            }
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
        return inventorySlot != null;
    }

    public void EquipItem(InventorySlot inventorySlot)
    {
        if(!inventorySlot.item.isEquippable)
            return;

        List<InventorySlot> itemsOfType = inventorySlots.FindAll(_inventorySlot => _inventorySlot.item.itemType == inventorySlot.item.itemType && _inventorySlot.isEquipped);
        foreach(InventorySlot itemOfType in itemsOfType){
            itemOfType.isEquipped = false;
        }
        inventorySlot.isEquipped = true;
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public Weapon GetEquippedWeapon(){
        return inventorySlots.Find(inventorySlot => inventorySlot.item.itemType == Item.ItemType.Weapon && inventorySlot.isEquipped).item as Weapon;
    }

    public Armor GetEquippedArmor(){
        return inventorySlots.Find(inventorySlot => inventorySlot.item.itemType == Item.ItemType.Armor && inventorySlot.isEquipped).item as Armor;
    }
}

[Serializable]
public class InventorySlot
{
    public Item item;
    public int quantity;

    public bool isEquipped;

    public InventorySlot(Item _item, int _quantity){
        item = _item;
        quantity = _quantity;
    }

    public void AddQuantity(int value){
        quantity += value;
    }

}