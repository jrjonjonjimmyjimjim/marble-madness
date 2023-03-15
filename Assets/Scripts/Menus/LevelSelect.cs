using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    /// <summary>
    ///     Implements the logic for the level select screen from the main menu
    ///     Load certain levels based on the buttons clicked
    ///     TODO: I want to somehow dynamically place the buttons somehow, but it seems like getting into too
    ///     much work, and I think that placing the buttons on the canvas with the editor is probably
    ///     fine
    /// </summary>
    public class LevelSelect : MonoBehaviour
    {
        /// <summary>
        ///     Give the user the option to click escape to return to the main menu from the level select screen
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("GameModeSelect");
        }

        /// <summary>
        ///     Load a certain scene as defined in each button
        /// </summary>
        /// <param name="level"></param>
        public void PlayLevel(string level)
        {
            SceneManager.LoadScene(level);
        }

        /// <summary>
        ///     Return to the main menu
        /// </summary>
        public void GoBack()
        {
            SceneManager.LoadScene("GameModeSelect");
        }
    }
}