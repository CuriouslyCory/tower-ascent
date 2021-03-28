using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public UpgradeableStat stat;

    public void SetStat(UpgradeableStat stat)
    {
        this.stat = stat;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Upgrade " + stat.statType;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = stat.price[stat.statLevel - 1].ToString()+"G";
        stat.OnLevelChanged += OnStatLevelChange;
    }

    private void OnStatLevelChange(object sender, StatChangeEventArgs e)
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = stat.price[stat.statLevel - 1].ToString()+"G";
    }

    private void OnDestroy() {
        stat.OnLevelChanged -= OnStatLevelChange;
    }
}
