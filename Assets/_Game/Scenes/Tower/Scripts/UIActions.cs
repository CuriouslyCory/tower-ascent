using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIActions : MonoBehaviour
{
    
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private TextMeshProUGUI goldText;
    
    [SerializeField]
    private TextMeshProUGUI potionsText;

    [SerializeField]
    private Button usePotButton;

    [SerializeField]
    private Button returnToTavernButton;

    [SerializeField]
    private PlayerCharacter playerCharacter;


    void Start()
    {
        gameState.inventory.OnGoldChanged += State_OnGoldChanged;
        gameState.inventory.OnItemListChanged += Inventory_OnItemListChanged;
        playerCharacter.OnPlayerStateChanged += PlayerCharacter_OnPlayerStateChanged;
        UpdateUIComponents();
    }

    private void OnDestroy() {
        gameState.inventory.OnGoldChanged -= State_OnGoldChanged;
        gameState.inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    private void UpdateUIComponents()
    {
        goldText.text = gameState.inventory.gold.ToString() + "G";
        potionsText.text = gameState.inventory.GetItemByType(Item.ItemType.HealthPotion).amount.ToString();
        UpdatePotionCount();
    }

    private void State_OnGoldChanged(object sender, StateEventArgs e)
    {
        goldText.text = e.value.ToString() + "G";
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        UpdatePotionCount();
    }

    private void PlayerCharacter_OnPlayerStateChanged(object sedner, PlayerStateEventArgs e) {
        switch(e.value){
            case PlayerCharacter.PlayerStates.Idle:
                returnToTavernButton.enabled = true;
                break;
            default:
                returnToTavernButton.enabled = false;
                break;
        }
    }

    private void UpdatePotionCount()
    {
        Item potions = gameState.inventory.GetItemByType(Item.ItemType.HealthPotion);
        potionsText.text = "Potions: " + potions.amount.ToString();
        usePotButton.enabled = potions.amount > 0 ? true : false;
    }

    public void OnUsePotionClick()
    {
        UsePotion();
    }

    public void OnReturnToTavernClick()
    {
        ReturnToTavern();
    }

    private void UsePotion()
    {
        bool usedItem = gameState.inventory.ConsumeItem(Item.ItemType.HealthPotion);
        if(usedItem){
            playerCharacter.healthSystem.Heal(10);
        }
    }


    private void ReturnToTavern()
    {
        SceneManager.LoadScene("Tavern");
    }

}