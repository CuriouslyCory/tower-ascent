
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="Game State")]
public class GameState : ScriptableObject
{
    
    public bool isInitialized = false;
    
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

        stats = new Dictionary<UpgradeableStat.StatType, UpgradeableStat> {
            {UpgradeableStat.StatType.Sword, new UpgradeableStat {statType = UpgradeableStat.StatType.Sword, statLevel = 1, price = new int[] {50, 100, 200, 400, 600}}},
            {UpgradeableStat.StatType.Armor, new UpgradeableStat {statType = UpgradeableStat.StatType.Armor, statLevel = 1, price = new int[] {50, 100, 200, 400, 600}}},
            {UpgradeableStat.StatType.Constitution, new UpgradeableStat {statType = UpgradeableStat.StatType.Constitution, statLevel = 1, price = new int[] {50, 100, 200, 400, 600}}}
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