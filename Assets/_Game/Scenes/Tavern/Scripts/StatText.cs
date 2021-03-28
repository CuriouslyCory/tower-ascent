using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatText : MonoBehaviour
{
    public UpgradeableStat stat;

    public void SetStat(UpgradeableStat stat)
    {
        this.stat = stat;
        transform.GetComponent<TextMeshProUGUI>().text = stat.statType + ": " + stat.statLevel.ToString();
        stat.OnLevelChanged += OnStatLevelChange;
    }

    private void OnStatLevelChange(object sender, StatChangeEventArgs e)
    {
        transform.GetComponent<TextMeshProUGUI>().text = stat.statType + ": " + stat.statLevel.ToString();
    }

    private void OnDestroy() {
        stat.OnLevelChanged -= OnStatLevelChange;
    }
}
