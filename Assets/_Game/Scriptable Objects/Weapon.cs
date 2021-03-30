using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Weapon", menuName="Scripted Items/Weapon")]
public class Weapon : Item
{
    public int numDice;
    public int diceSides;
    private void Awake() {
        itemType = Item.ItemType.Weapon;
    }
}