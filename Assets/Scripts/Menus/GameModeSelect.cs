using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace Menus{
    /// <summary>
    ///     Implements the logic for the game mode select screen from the main menu
    ///     Load certain levels based on the buttons clicked
    ///     TODO: I want to somehow dynamically place the buttons somehow, but it seems like getting into too
    ///     much work, and I think that placing the buttons on the canvas with the editor is probably
    ///     fine
    /// </summary>

    public class GameModeSelect : MonoBehaviour
    {
        /// <summary>
        ///     Give the user the option to click escape to return to the main menu from the game mode select screen
        /// </summary>
        /// 

        private void Start()
        {
            GameManager.UpdateGameMode(GameMode.Menu);
        }

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
            if(level == "Time Attack"){
                // gameMode = GameMode.Time;
                GameManager.UpdateGameMode(GameMode.Time);
                SceneManager.LoadScene("Level1");
            }else if(level == "Tutorial"){
                GameManager.UpdateGameMode(GameMode.Tutorial);
                SceneManager.LoadScene("Tutorial");
            }else if(level == "Level Select"){
                GameManager.UpdateGameMode(GameMode.Level);
                SceneManager.LoadScene("LevelSelect");
            }else if(level == "Survival"){
                GameManager.UpdateGameMode(GameMode.Survival);
                SceneManager.LoadScene("Level1");
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
