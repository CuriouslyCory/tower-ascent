
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="Game State")]
public class GameState : ScriptableObject
{
    
    public bool isInitialized = false;
    [SerializeField]
    private Weapon defaultWeapon;
    [SerializeField]
    private Armor defaultArmor;
    
    public Inventory inventory;
    

    [SerializeField]
    private int _playerMaxHealth;
    public int playerMaxHealth {
        get => _playerMaxHealth;
        set {
            if(_playerMaxHealth == value)
                return;
            _playerMaxHealth = value;
        }
    }

    [SerializeField] public Dictionary<UpgradeableStat.StatType, UpgradeableStat> stats;

    private void Awake() {
        Debug.Log("GameState awake");
        
    }

    private void SetDefaultValues()
    {
        inventory.gold = 10;
        playerMaxHealth = 10;
        if(inventory.inventorySlots.Count == 0){
            inventory.AddItem(defaultArmor, 1);
            inventory.EquipItem(inventory.inventorySlots[0]);
            inventory.AddItem(defaultWeapon, 1);
            inventory.EquipItem(inventory.inventorySlots[1]);
        }

        stats = new Dictionary<UpgradeableStat.StatType, UpgradeableStat> {
            {UpgradeableStat.StatType.Strength, new UpgradeableStat {statType = UpgradeableStat.StatType.Strength, statLevel = 1, price = new int[] {50, 100, 200, 400, 600,1000,1500,2500,4000,6000}}},
            {UpgradeableStat.StatType.Dexterity, new UpgradeableStat {statType = UpgradeableStat.StatType.Dexterity, statLevel = 1, price = new int[] {50, 100, 200, 400, 600,1000,1500,2500,4000,6000}}},
            {UpgradeableStat.StatType.Constitution, new UpgradeableStat {statType = UpgradeableStat.StatType.Constitution, statLevel = 1, price = new int[] {50, 100, 200, 400, 600,1000,1500,2500,4000,6000}}}
        };
    }

    public void Initialize()
    {
        isInitialized = true;
        SetDefaultValues();
    }

}

public class StateEventArgs: EventArgs
{
    public int value;
}