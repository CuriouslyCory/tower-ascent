using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Armor", menuName="Scripted Items/Armor")]
public class Armor : Item
{
    public int armorClass;

    private void Awake() {
        itemType = Item.ItemType.Armor;
        isEquippable = true;
    }
}
