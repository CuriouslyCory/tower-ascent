using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeItem
{
    public string name;
    public string cost;

    public Action OnClick;
}
