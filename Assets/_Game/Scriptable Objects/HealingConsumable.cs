using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Health", menuName="Scripted Items/Health Restore")]
public class HealingConsumable : Item
{
    public int healingAmount;

    private void Awake() {
        itemType = Item.ItemType.HealingConsumable;
    }
}
