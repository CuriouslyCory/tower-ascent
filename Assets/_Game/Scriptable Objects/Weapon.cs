using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Weapon", menuName="Scripted Items/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int numDice;
    public int diceSides;
}
