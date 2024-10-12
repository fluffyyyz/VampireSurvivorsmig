using UnityEngine;
using UnityEngine.SceneManagement;  // To work with scene loading

public class GameOverManager : MonoBehaviour
{
    // This function will reload the current active scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reloads the current scene
    }

    // This function can be used to go back to the Main Menu if you have one
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Replace with the name of your Main Menu scene
    }
}
