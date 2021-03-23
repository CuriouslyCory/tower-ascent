using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGameMenu : MonoBehaviour
{
    [SerializeField]
    GameState gameState;

    public void PlayGame()
    {
        gameState.Initialize();
        gameState.inventory.gold = 0;
        gameState.playerMaxHealth = 10;
        gameState.armorLevel = 1;
        gameState.swordLevel = 1;
        gameState.constitutionLevel = 1;
        SceneManager.LoadScene("Tavern");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
