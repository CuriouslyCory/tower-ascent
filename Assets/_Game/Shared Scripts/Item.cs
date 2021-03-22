using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item: IEquatable<Item>
{
    public enum ItemType {
        HealthPotion,
        Treasure,
        Weapon
    }

    public ItemType itemType;
    public int amount;

    public bool IsStackable()
    {
        switch (itemType){
            default:
            case ItemType.HealthPotion:
                return true;
            case ItemType.Treasure:
                return false;
        }
    }

    public bool Equals(Item other)
    {
        if (other == null) return false;
        return (this.itemType.Equals(other.itemType));
    }

}
