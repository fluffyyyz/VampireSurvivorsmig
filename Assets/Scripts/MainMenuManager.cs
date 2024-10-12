using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");  // Replace "Game" with the exact name of your game scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // This method will be used to load the main menu from the game
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");  // Make sure "MainMenuScene" matches your main menu scene name
    }
}
