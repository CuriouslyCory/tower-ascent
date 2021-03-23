
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
    public int playerMaxHealth
    {
        get => _playerMaxHealth;
        set {
            if(_playerMaxHealth == value)
                return;
            _playerMaxHealth = value;
        }
    }

    public int swordLevel;
    public int armorLevel;
    public int constitutionLevel;

    public void Initialize()
    {
        isInitialized = true;
    }

}

public class StateEventArgs: EventArgs
{
    public int value;
}