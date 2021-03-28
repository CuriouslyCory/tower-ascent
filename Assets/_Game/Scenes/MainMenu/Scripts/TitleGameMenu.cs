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
        SceneManager.LoadScene("Tavern");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
