using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeableStat
{
    public enum StatType {
        Sword,
        Armor,
        Constitution
    }
    public StatType statType;
    public EventHandler<StatChangeEventArgs> OnLevelChanged;
    private int _statLevel;
    
    [SerializeField]
    public int statLevel {
        get => _statLevel;
        set {
            if(_statLevel == value)
                return;
            _statLevel = value;
            OnLevelChanged?.Invoke(this, new StatChangeEventArgs {statType = statType, value = _statLevel});
        }
    }

    [SerializeField]
    public int[] price;

}

public class StatChangeEventArgs: EventArgs
{
    public UpgradeableStat.StatType statType;
    public int value;
}