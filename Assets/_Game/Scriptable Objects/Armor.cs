using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Armor", menuName="Scripted Items/Armor")]
public class Armor : ScriptableObject
{
    public string armorName;
    public int armorClass;
}
