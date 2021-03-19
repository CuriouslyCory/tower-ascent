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
    

    private void Start() 
    {
        UpdateInventoryUIComponents();
        
        gameState.inventory.OnItemListChanged += Inventory_OnItemListChanged;
        gameState.OnGoldChanged += State_OnGoldChanged;
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
        goldText.text = gameState.gold.ToString() + "G";
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
        if(gameState.gold >= 10){
            gameState.gold -= 10;
            gameState.inventory.AddItem(new Item {itemType = Item.ItemType.HealthPotion, amount = 1});
        }
    }

    private void OnMouseUp() {
        
    }
}
