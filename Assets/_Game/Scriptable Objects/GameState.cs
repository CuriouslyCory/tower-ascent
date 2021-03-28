
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

    [SerializeField] public Dictionary<string, UpgradeableStat> stats;

    private void Awake() {
        Debug.Log("GameState awake");
        
    }

    private void SetDefaultValues()
    {
        inventory.gold = 400;
        playerMaxHealth = 10;

        stats = new Dictionary<string, UpgradeableStat> {
            {"sword", new UpgradeableStat {name = "Sword", statLevel = 1, price = new int[] {50, 100, 200, 400, 600}}},
            {"armor", new UpgradeableStat {name = "Armor", statLevel = 1, price = new int[] {50, 100, 200, 400, 600}}},
            {"constitution", new UpgradeableStat {name = "Consitution", statLevel = 1, price = new int[] {50, 100, 200, 400, 600}}}
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