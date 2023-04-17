using GameLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    /// <summary>
    ///     Implements the logic for the game mode select screen from the main menu
    ///     Load certain levels based on the buttons clicked
    /// </summary>
    public class GameModeSelect : MonoBehaviour
    {
        /// <summary>
        ///     Give the user the option to click escape to return to the main menu from the game mode select screen
        /// </summary>
        private void Start()
        {
            GameModeManager.UpdateGameMode(GameMode.Menu);
        }

        /// <summary>
        ///     Give the user the option to click escape to return to the main menu from the game mode select screen
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        ///     Load a certain scene as defined in each button
        /// </summary>
        /// <param name="level"></param>
        public void PlayLevel(string level)
        {
            switch (level)
            {
                case "Time Attack":
                    GameModeManager.UpdateGameMode(GameMode.Time);
                    GameManager.StartPlay(GameMode.Time);
                    SceneManager.LoadScene("Level1");
                    break;
                case "Tutorial":
                    GameModeManager.UpdateGameMode(GameMode.Tutorial);
                    GameManager.StartPlay(GameMode.Tutorial);
                    SceneManager.LoadScene("Tutorial");
                    break;
                case "Level Select":
                    GameModeManager.UpdateGameMode(GameMode.Level);
                    GameManager.StartPlay(GameMode.Level);
                    SceneManager.LoadScene("LevelSelect");
                    break;
                case "Survival":
                    GameModeManager.UpdateGameMode(GameMode.Survival);
                    GameManager.StartPlay(GameMode.Survival);
                    SceneManager.LoadScene("Level1");
                    break;
            }
        }

        /// <summary>
        ///     Return to the main menu
        /// </summary>
        public void GoBack()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}