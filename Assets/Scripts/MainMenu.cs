using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// // This script handles starting the game from the main menu by loading the next scene in the build index.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void PlayGame()  // Loads next scene in the build index rather than loading by scene name or number.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() // Exits application when running in build
    {
        Application.Quit();
    }
}
