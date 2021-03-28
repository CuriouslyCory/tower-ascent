using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using CodeMonkey.Utils;
using TMPro;

public class TavernActions : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI potionsText;
    
    [SerializeField]
    private GameObject pfUpgradeButton;

    [SerializeField]
    private Transform menuContainer;

    [SerializeField]
    private GameObject pfStatText;

    [SerializeField]
    private Transform statsPanel;

    [SerializeField]
    private TextMeshProUGUI maxHealthText;

    private List<GameObject> buttonObjs;
    private List<GameObject> statTexts;
    


    private void Start() 
    {
        buttonObjs = new List<GameObject>();
        statTexts = new List<GameObject>();

        if(gameState.stats == null || gameState.stats.Count == 0){
            gameState.Initialize();
        }
        
        UpdateInventoryUIComponents();
        
        gameState.inventory.OnItemListChanged += Inventory_OnItemListChanged;
        gameState.inventory.OnGoldChanged += State_OnGoldChanged;

        GenerateUpgradeMenu();
        maxHealthText.text = "Max HP: " + gameState.playerMaxHealth.ToString();
        
    }
    private void OnDestroy() {
        gameState.inventory.OnItemListChanged -= Inventory_OnItemListChanged;
        gameState.inventory.OnGoldChanged -= State_OnGoldChanged;
    }

    private void GenerateUpgradeMenu()
    {
        foreach(UpgradeableStat stat in gameState.stats.Values)
        {
            CreateUpgradeButton(stat);
            CreateStatText(stat);
        }
    }

    private void CreateUpgradeButton(UpgradeableStat stat)
    {
        buttonObjs.Add(Instantiate(pfUpgradeButton, menuContainer));
        buttonObjs[buttonObjs.Count - 1].GetComponent<UpgradeButton>().SetStat(stat);
        
        buttonObjs[buttonObjs.Count - 1].GetComponent<Button_UI>().ClickFunc = () => {
            OnUpgradeClick(stat);
        };
    }

    private void CreateStatText(UpgradeableStat stat)
    {
        statTexts.Add(Instantiate(pfStatText, statsPanel));
        statTexts[statTexts.Count - 1].GetComponent<StatText>().SetStat(stat);
    }

    public void OnUpgradeClick(UpgradeableStat stat)
    {
        Debug.Log("Upgrade clicked: " + stat.statType);
        int statLevel = stat.statLevel;
        Debug.Log("Stat current lvl: " + statLevel);
        int statCost = stat.price[statLevel - 1];
        Debug.Log("Stat current cost: " + statCost);
        if(gameState.inventory.gold > statCost){
            stat.statLevel++;
            gameState.inventory.gold -= statCost;
        }
        if(stat.statType == UpgradeableStat.StatType.Constitution){
            gameState.playerMaxHealth = stat.statLevel * 10;
            maxHealthText.text = "Max HP: " + gameState.playerMaxHealth.ToString();
        }
    }

    

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        UpdateInventoryUIComponents();
    }

    private void State_OnGoldChanged(object sender, System.EventArgs e)
    {
        UpdateInventoryUIComponents();
    }

    private void UpdateInventoryUIComponents()
    {
        goldText.text = gameState.inventory.gold.ToString() + "G";
        Item potions = gameState.inventory.GetItemByType(Item.ItemType.HealthPotion);
        potionsText.text = "Potions: " + potions.amount.ToString();
    }

    // Start is called before the first frame update
    public void OnClickSmashTower()
    {
        SceneManager.LoadScene("Tower", LoadSceneMode.Single);
    }

    public void OnClickBuyPotion()
    {
        if(gameState.inventory.gold >= 10){
            gameState.inventory.gold -= 10;
            gameState.inventory.AddItem(new Item {itemType = Item.ItemType.HealthPotion, amount = 1});
        }
    }
} 