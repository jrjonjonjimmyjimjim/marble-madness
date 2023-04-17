using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    /// <summary>
    ///     This class is responsible for managing the game state.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private static int level = 1;
        private static int maxLevel = 3;
        public static int lives = 5;
        public static float timer = 30;
        public static float music_time;

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        ///     Each frame, check the lives or timer to see if the game is over.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void CheckStatus()
        {
            switch (GameModeManager.GameMode)
            {
                case GameMode.Time when timer > 0.0:
                    timer -= Time.deltaTime;
                    break;
                case GameMode.Time:
                    SceneManager.LoadScene("GameOver");
                    break;
                case GameMode.Survival:
                {
                    if (lives <= 0) SceneManager.LoadScene("GameOver");
                    break;
                }
                case GameMode.Tutorial:
                    break;
                case GameMode.Level:
                    break;
                case GameMode.Menu:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     When the game starts, set parameters according to the game mode.
        /// </summary>
        /// <param name="mode"></param>
        public static void StartPlay(GameMode mode)
        {
            level = 1;
            switch (mode)
            {
                case GameMode.Time:
                    timer = 30;
                    break;
                case GameMode.Survival:
                    lives = 5;
                    break;
            }
        }

        /// <summary>
        ///     Move to the next level.
        ///     Add time if the game mode is time; otherwise, move to the game over screen if the level is the last level.
        /// </summary>
        public static void GoToNextLevel()
        {
            level++;
            music_time = PlayMusic.audio.time;
            if (level > maxLevel)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                timer += 30;
                SceneManager.LoadScene("Level" + level);
            }
        }
    }
}