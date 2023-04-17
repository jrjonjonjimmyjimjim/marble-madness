using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    /// <summary>
    ///     Controller for the goal level
    /// </summary>
    public class GoalLevelController : MonoBehaviour
    {
        /// <summary>
        ///     Move the player to the next level if there are any left; else go to the game over screen
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;

            switch (GameModeManager.GameMode)
            {
                // Go to the next level if the game mode is survival or time attack
                case GameMode.Survival:
                case GameMode.Time:
                    GameManager.GoToNextLevel();
                    break;
                // Go to the main menu if the game mode is tutorial
                case GameMode.Tutorial:
                    SceneManager.LoadScene("MainMenu");
                    break;
                // Go to the level select screen if the game mode is single level
                case GameMode.Level:
                    SceneManager.LoadScene("LevelSelect");
                    break;
                // Throw an exception if the game mode is not recognized
                case GameMode.Menu:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}