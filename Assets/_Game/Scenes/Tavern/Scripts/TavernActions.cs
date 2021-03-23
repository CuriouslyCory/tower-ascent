using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private TextMeshProUGUI maxHpText;
    [SerializeField]
    private TextMeshProUGUI constitutionLevelText;
    [SerializeField]
    private TextMeshProUGUI swordLevelText;
    [SerializeField]
    private TextMeshProUGUI armorLevelText;

    private void Start() 
    {
        UpdateInventoryUIComponents();
        
        gameState.inventory.OnItemListChanged += Inventory_OnItemListChanged;
        gameState.inventory.OnGoldChanged += State_OnGoldChanged;
        maxHpText.text = "Max HP: " + gameState.playerMaxHealth.ToString();
        constitutionLevelText.text = "Constitution Level: " + gameState.constitutionLevel.ToString();
        swordLevelText.text = "Sword Level: " + gameState.swordLevel.ToString();
        armorLevelText.text = "Armor Level: " + gameState.armorLevel.ToString();

    }

    private void OnDestroy() {
        gameState.inventory.OnItemListChanged -= Inventory_OnItemListChanged;
        gameState.inventory.OnGoldChanged -= State_OnGoldChanged;
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

    public void OnClickTrainConstitution()
    {
        TrainConstitution();
    }

    private void TrainConstitution()
    {
        if(gameState.inventory.gold >= 100){
            gameState.inventory.gold -= 100;
            gameState.constitutionLevel++;
            gameState.playerMaxHealth += 10;
            maxHpText.text = "Max HP: " + gameState.playerMaxHealth.ToString();
            constitutionLevelText.text = "Constitution Level: " + gameState.constitutionLevel.ToString();
        }
    }

    public void OnClickTrainSword()
    {
        TrainSword();
    }

    private void TrainSword()
    {
        if(gameState.inventory.gold >= 100){
            gameState.inventory.gold -= 100;
            gameState.swordLevel++;
            swordLevelText.text = "Sword Level: " + gameState.swordLevel.ToString();
        }
    }

    public void OnClickTrainArmor()
    {
        TrainArmor();
    }

    private void TrainArmor()
    {
        if(gameState.inventory.gold >= 100){
            gameState.inventory.gold -= 100;
            gameState.armorLevel++;
            armorLevelText.text = "Armor Level: " + gameState.armorLevel.ToString();
        }

    }

}
