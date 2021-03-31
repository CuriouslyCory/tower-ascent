using System;
using UnityEngine;

[Serializable]
public class Item: ScriptableObject
{
    public enum ItemType {
        HealingConsumable,
        Treasure,
        Weapon,
        Armor
    }

    public string itemName;

    public ItemType itemType;
    public int quantity;
    public int price;

    public Sprite sprite;

    public Boolean isEquippable = false;
    public Boolean isConsumable = false;


    public bool IsStackable()
    {
        switch (itemType){
            default:
            case ItemType.HealingConsumable:
                return true;
            case ItemType.Armor:
            case ItemType.Weapon:
                return false;
        }
    }

}
