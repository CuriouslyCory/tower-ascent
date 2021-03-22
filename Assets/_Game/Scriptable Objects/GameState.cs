
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="Game State")]
public class GameState : ScriptableObject
{
    
    public event EventHandler<StateEventArgs> OnPlayerHealthChanged;
    
    public bool isInitialized = false;
    
    public Inventory inventory;
    

    [SerializeField]
    private int _playerHealth;
    public int playerHealth
    {
        get => _playerHealth;
        set {
            if(_playerHealth == value)
                return;
            _playerHealth = value;
            OnPlayerHealthChanged?.Invoke(this, new StateEventArgs {value = _playerHealth});
        }
    }

    public void Initialize()
    {
        inventory = new Inventory();
        isInitialized = true;
        inventory.gold = 10;
        playerHealth = 12;
    }

}

public class StateEventArgs: EventArgs
{
    public int value;
}