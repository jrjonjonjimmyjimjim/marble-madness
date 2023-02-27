using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///     Define and aggregate behaviour for the main menu buttons
/// </summary>
public class MenuManager : MonoBehaviour
{
    public int gameStartScene;

    /// <summary>
    ///     Start the game based on some starting scene (defined in the build settings)
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    /// <summary>
    ///     Quit the game when the quit button is pressed
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}