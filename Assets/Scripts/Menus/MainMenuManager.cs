using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    /// <summary>
    ///     Define and aggregate behaviour for the main menu buttons
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        public int gameStartScene;

        /// <summary>
        ///     Start the game based on some starting scene (defined in the build settings)
        /// </summary>
        public void ToGameModeSelect()
        {
            SceneManager.LoadScene("GameModeSelect");
        }

        /// <summary>
        ///     Quit the game when the quit button is pressed
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}