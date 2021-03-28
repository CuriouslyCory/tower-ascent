using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeableStat
{
    public string name;
    public EventHandler<StatChangeEventArgs> OnLevelChanged;
    private int _statLevel;
    
    [SerializeField]
    public int statLevel {
        get => _statLevel;
        set {
            if(_statLevel == value)
                return;
            _statLevel = value;
            OnLevelChanged?.Invoke(this, new StatChangeEventArgs {name = name, value = _statLevel});
        }
    }

    [SerializeField]
    public int[] price;

}

public class StatChangeEventArgs: EventArgs
{
    public string name;
    public int value;
}